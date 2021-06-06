using System;
using Exercises;
using Exercises.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cache.Tests  {

    [TestClass]
    public class CacheTests  {

        [TestMethod]
        public void ShouldAddAnItemToCacheWhenEmpty() {
            Cache cache = new Cache(3);
            Image item = new Image() {
                InstanceUid = Guid.NewGuid().ToString()
            };
            cache.PutItem(item.InstanceUid, item);
            Assert.IsNotNull(cache.GetItem(item.InstanceUid), "item not found in cache");
        }

        [TestMethod, Ignore]
        [ExpectedException(typeof(InvalidCacheKeyException))]
        public void ShouldThrowExceptionWhenCacheKeyIsInvalid()  {
            Cache cache = new Cache(3);
            Image item = new Image() {InstanceUid = Guid.NewGuid().ToString()};
            cache.PutItem(item.InstanceUid, item);
            Assert.IsNotNull(cache.GetItem(item.InstanceUid), "item not found in cache");
        }

        [TestMethod]
        public void ShouldRemoveLRUItemWhenCacheIsFull() {
            Cache cache = new Cache(3);
            Image item1 = new Image() {InstanceUid = Guid.NewGuid().ToString()};
            cache.PutItem(item1.InstanceUid, item1);

            var item2 = new Image() { InstanceUid = Guid.NewGuid().ToString() };
            cache.PutItem(item2.InstanceUid, item2);

            var item3 = new Image() { InstanceUid = Guid.NewGuid().ToString() };
            cache.PutItem(item3.InstanceUid, item3);
            // Cache is full.

            // Make item3 as the least recently used.
            Assert.IsNotNull(cache.GetItem(item1.InstanceUid));
            Assert.IsNotNull(cache.GetItem(item2.InstanceUid));

            var item4 = new Image() { InstanceUid = Guid.NewGuid().ToString() };
            cache.PutItem(item4.InstanceUid, item4);

            Assert.IsNull(cache.GetItem(item3.InstanceUid), "least recently used item is not removed from cache");
            Assert.IsNotNull(item4.InstanceUid);
        }

        [TestMethod]
        public void ShouldReturnNullWhenCacheMiss()  {
            Cache cache = new Cache(3);
            var cachedItem = cache.GetItem("123");
            Assert.IsNull(cachedItem);
        }

    }
}
