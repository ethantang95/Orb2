using NUnit.Framework;
using OrbCore.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCoreTests.CacheTests {
    [TestFixture]
    class DiscordCacheTests {
        DiscordObjectsCache<int> _cache;
        ulong _idCount;

        [OneTimeSetUp]
        public void SetUp() {
            _cache = new DiscordObjectsCache<int>();
            _idCount = 0;
        }

        [Test]
        public void TestAdd() {
            var id = GetAndUpdateId();
            _cache.SetMember(id, 1);
            Assert.AreEqual(1, _cache.GetMember(id).Value);
        }

        [Test]
        public void TestUpdate() {
            var id = GetAndUpdateId();
            _cache.SetMember(id, 1);
            _cache.SetMember(id, 2);
            Assert.AreEqual(2, _cache.GetMember(id).Value);
        }

        [Test]
        public void TestChangeIfExistWhenExists() {
            var id = GetAndUpdateId();
            _cache.SetMember(id, 1);
            _cache.ChangeIfExists(id, 2);
            Assert.AreEqual(2, _cache.GetMember(id).Value);
        }

        [Test]
        public void TestChangeIfExistWhenNotExists() {
            var id = GetAndUpdateId();
            _cache.ChangeIfExists(id, 2);
            Assert.IsFalse(_cache.GetMember(id).Present);
        }

        [Test]
        public void TestGettingNonExistentMember() {
            var id = GetAndUpdateId();
            Assert.IsFalse(_cache.GetMember(id).Present);
        }

        [Test]
        public void TestGetMemberOrCall() {
            var id = GetAndUpdateId();
            Assert.AreEqual(1, _cache.GetMemberOrCall(id, (s) => { return 1; }));
            Assert.AreEqual(1, _cache.GetMember(id).Value);
        }

        [Test]
        public void TestRemoveMember() {
            var id = GetAndUpdateId();
            _cache.SetMember(id, 1);
            Assert.AreEqual(1, _cache.GetMember(id).Value);
            _cache.RemoveMember(id);
            Assert.IsFalse(_cache.GetMember(id).Present);
        }

        [Test]
        public void TestHasMemberExists() {
            var id = GetAndUpdateId();
            _cache.SetMember(id, 1);
            Assert.IsTrue(_cache.HasMember(id));
        }

        [Test]
        public void TestHasMemberNotExists() {
            var id = GetAndUpdateId();
            Assert.IsFalse(_cache.HasMember(id));
        }

        private ulong GetAndUpdateId() {
            _idCount++;
            return _idCount;
        }
    }
}
