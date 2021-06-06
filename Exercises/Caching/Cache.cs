using System.Collections.Generic;
using Exercises;
using Exercises.Caching;

namespace Cache {
    public class Cache {

        private readonly int cacheSize = 10;

        public Cache(int cacheSize) {
            this.cacheSize = cacheSize;
        }

        public void PutItem(string key, ImageDescription value) {
            if (string.IsNullOrWhiteSpace(key)) {
                throw new InvalidCacheKeyException();
            }

            //todo:// Checck if the cache is full. if true then remove the recently used item.
            if (IsCacheFull())  {
                RemoveLeastRecentlyUsedItem();
            } else  {
                AddItemToCache();
            }
            // todo:// else simply add item to cache.
        }

        private void AddItemToCache() {
            //todo://
        }

        private bool IsCacheFull() {
            //todo://
            return false;
        }

        private void RemoveLeastRecentlyUsedItem()  {
            //todo://
        }

        public ImageDescription GetItem(string id)  {
            //todo:// if the item present return the item else return null.
            return null;
        }
    }
}