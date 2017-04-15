using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Core.Cache {
    class CacheItemLastUsedTracker<T>{

        private DiscordObjectsCache<T> _cache;
        private SortedSet<ulong> _sortedLastedUsedStamps;
        private Dictionary<ulong, ulong> _stampToObjIdMap;
        private Dictionary<ulong, ulong> _objIdToStampMap;
        private ulong _lastGivenStamp;
        private int _maxCapacity;
        private object _lock;

        private const double REMOVEPERCENTAGE = 0.1;

        public CacheItemLastUsedTracker(int maxCapacity, DiscordObjectsCache<T> cache) {
            _maxCapacity = maxCapacity;
            _cache = cache;
            _sortedLastedUsedStamps = new SortedSet<ulong>();
            _stampToObjIdMap = new Dictionary<ulong, ulong>();
            _objIdToStampMap = new Dictionary<ulong, ulong>();
            _lastGivenStamp = 0;
            _lock = new object();
        }

        public void Update(ulong objId) {
            if (InCache(objId)) {
                UpdateStamp(objId);
            } else {
                AddNewObject(objId);
                CheckAndRemoveOldUsed();
            }
        }

        public void Remove(ulong objId) {
            if (_stampToObjIdMap.ContainsKey(objId)) {
                var stampId = _objIdToStampMap[objId];
                RemoveStamp(objId);
            }
        }

        private bool InCache(ulong objId) {
            return _objIdToStampMap.ContainsKey(objId);
        }

        private void UpdateStamp(ulong objId) {
            var stamp = GetAndUpdateStamp();
            var prevStamp = _objIdToStampMap[objId];

            RemoveStamp(prevStamp);
            AddStamp(stamp, objId);
        }

        private void RemoveStamp(ulong stamp) {
            var objId = _stampToObjIdMap[stamp];

            _objIdToStampMap.Remove(objId);
            _sortedLastedUsedStamps.Remove(stamp);
            _stampToObjIdMap.Remove(stamp);
        }

        private void AddNewObject(ulong objId) {
            var stamp = GetAndUpdateStamp();
            AddStamp(stamp, objId);
        }

        private void AddStamp(ulong stamp, ulong objId) {
            _objIdToStampMap.Add(objId, stamp);
            _sortedLastedUsedStamps.Add(stamp);
            _stampToObjIdMap.Add(stamp, objId);
        }

        private void CheckAndRemoveOldUsed() {
            if (ExceedsCapacity()) {
                RemoveOldUsed();
            }
        }

        private void RemoveOldUsed() {
            var toRemove = Math.Max((int)(_maxCapacity * REMOVEPERCENTAGE), 1);
            for (var i = 0; i < toRemove; i++) {
                RemoveOldest();
            }
        }

        private void RemoveOldest() {
            var oldestStamp = _sortedLastedUsedStamps.Min;
            var oldestobjId = _stampToObjIdMap[oldestStamp];

            RemoveStamp(oldestStamp);
            _cache.RemoveMember(oldestobjId);
        }

        private bool ExceedsCapacity() {
            return _objIdToStampMap.Count > _maxCapacity;
        }

        private ulong GetAndUpdateStamp() {
            lock (_lock) {
                var stamp = _lastGivenStamp;
                _lastGivenStamp++;
                return stamp;
            }
        }
    }
}
