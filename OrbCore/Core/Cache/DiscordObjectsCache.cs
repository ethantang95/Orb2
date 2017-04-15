using HelperCore.Optional;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Core.Cache {
    internal class DiscordObjectsCache<T> {
        private ConcurrentDictionary<ulong, T> _cacheDictionary;
        private CacheItemLastUsedTracker<T> _cacheTracker;

        public DiscordObjectsCache() : this(8192) {

        }

        public DiscordObjectsCache(int capacity) {
            _cacheDictionary = new ConcurrentDictionary<ulong, T>();
            _cacheTracker = new CacheItemLastUsedTracker<T>(capacity, this);
        }

        public void SetMember(ulong id, T obj) {
            if (HasMember(id)) {
                var old = GetMember(id).Value;
                _cacheDictionary.TryUpdate(id, obj, old);
            } else {
                _cacheDictionary.TryAdd(id, obj);
                UpdateObjectTrack(id);
            }
        }

        public void ChangeIfExists(ulong id, T obj) {
            if (HasMember(id)) {
                SetMember(id, obj);
            }
        }

        public Optional<T> GetMember(ulong id) {
            if (HasMember(id)) {
                UpdateObjectTrack(id);
                return Optional.From(_cacheDictionary[id]);
            } else {
                return Optional<T>.FromNull();
            }
        }

        public T GetMemberOrCall(ulong id, GetObject<T> call) {
            if (HasMember(id)) {
                return GetMember(id).Value;
            } else {
                return CallAddReturn(id, call);
            }
        }

        public void RemoveMember(ulong id) {
            if (HasMember(id)) {
                T content;
                _cacheDictionary.TryRemove(id, out content);
                RemoveFromObjectTrack(id);
            }
        }

        public bool HasMember(ulong id) {
            return _cacheDictionary.ContainsKey(id);
        }

        private T CallAddReturn(ulong id, GetObject<T> call) {
            var obj = call(id);
            SetMember(id, obj);
            return obj;
        }

        private void UpdateObjectTrack(ulong id) {
            _cacheTracker.Update(id);
        }

        private void RemoveFromObjectTrack(ulong id) {
            _cacheTracker.Remove(id);
        }
    }

    internal delegate T GetObject<T>(ulong id);
}
