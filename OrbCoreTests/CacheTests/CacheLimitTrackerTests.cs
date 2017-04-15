using NUnit.Framework;
using OrbCore.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCoreTests.CacheTests {

    [TestFixture]
    class CacheLimitTrackerTests {

        [Test]
        public void TestLImitReaching() {
            var cache = new DiscordObjectsCache<int>(30);
            AddToCache(cache, 30);

            cache.SetMember(999, 1);

            //removing mechanism should hit, 0, 1, and 2 should be gone
            Assert.IsFalse(cache.HasMember(0));
            Assert.IsFalse(cache.HasMember(1));
            Assert.IsFalse(cache.HasMember(2));
            Assert.IsTrue(cache.HasMember(3));
            Assert.IsTrue(cache.HasMember(999));

            //add 1 more and assert that no members were removed
            cache.SetMember(998, 1);
            Assert.IsTrue(cache.HasMember(3));
        }

        [Test]
        public void TestCacheHitRemoveOld() {
            var cache = new DiscordObjectsCache<int>(20);
            AddToCache(cache, 20);

            cache.GetMember(0);
            cache.SetMember(999, 1);

            //0 has hit, so 1 and 2 should be gone
            Assert.IsTrue(cache.HasMember(0));
            Assert.IsFalse(cache.HasMember(1));
            Assert.IsFalse(cache.HasMember(2));
        }

        private void AddToCache(DiscordObjectsCache<int> cache, int amount) {
            for (var i = 0; i < amount; i++) {
                cache.SetMember((ulong)i, 1);
            }
        }
    }
}
