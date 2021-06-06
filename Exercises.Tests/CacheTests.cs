using Exercises;
using Exercises.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cache.Tests  {

    [TestClass]
    public class CacheTests  {

        [TestMethod]
        public void ShouldAddAnItemToCacheWhenEmpty() {
            Cache cache = new Cache(3);
            ImageDescription item = new ImageDescription();
            cache.AddItem(item);
            Assert.IsNotNull(cache.TryGetItem(item.Id), "item not found in cache");
        }

        [TestMethod, Ignore]
        [ExpectedException(typeof(InvalidCacheKeyException))]
        public void ShouldThrowExceptionWhenCacheKeyIsInvalid()  {
            Cache cache = new Cache(3);
            ImageDescription item = new ImageDescription();
            cache.AddItem(item);
            Assert.IsNotNull(cache.TryGetItem(item.Id), "item not found in cache");
        }

        [TestMethod]
        public void ShouldRemoveLRUItemWhenCacheIsFull() {
            Cache cache = new Cache(3);
            ImageDescription item1 = new ImageDescription();
            cache.AddItem(item1);

            var item2 = new ImageDescription();
            cache.AddItem(item2);

            var item3 = new ImageDescription();
            cache.AddItem(item3);
            // Cache is full.

            // Make item3 as the least recently used.
            Assert.IsNotNull(cache.TryGetItem(item1.Id));
            Assert.IsNotNull(cache.TryGetItem(item2.Id));

            var item4 = new ImageDescription();
            cache.AddItem(item4);

            Assert.IsNull(cache.TryGetItem(item3.Id), "least recently used item is not removed from cache");
            Assert.IsNotNull(item4.Id);
        }

        [TestMethod]
        public void ShouldReturnNullWhenCacheMiss()  {
            Cache cache = new Cache(3);
            var cachedItem = cache.TryGetItem("123");
            Assert.IsNull(cachedItem);
        }

    }
}
