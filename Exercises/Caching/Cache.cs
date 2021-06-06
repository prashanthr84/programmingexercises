using System.Collections.Generic;
using Exercises;
using Exercises.Caching;

namespace Cache {
    public class Cache {

        private readonly LinkedList<ImageDescription> linkedList;
        private Dictionary<string, LinkedListNode<ImageDescription>> cacheDictionary;
        private readonly int cacheSize = 10;

        public Cache(int cacheSize) {
            this.cacheSize = cacheSize;
            cacheDictionary = new Dictionary<string, LinkedListNode<ImageDescription>>(cacheSize);
            linkedList = new LinkedList<ImageDescription>();
        }

        public void PutItem(string key, ImageDescription value) {
            if (string.IsNullOrWhiteSpace(key)) {
                throw new InvalidCacheKeyException();
            }

            if(cacheDictionary.Count == cacheSize) {
                RemoveLeastRecentlyUsedItem();
            }

            if (!cacheDictionary.ContainsKey(key)) {
                LinkedListNode<ImageDescription> node = new LinkedListNode<ImageDescription>(value);
                linkedList.AddFirst(node);
                cacheDictionary.Add(key, node);
            }
        }

        private void RemoveLeastRecentlyUsedItem()  {
            var lastNode = linkedList.Last;
            linkedList.RemoveLast();
            cacheDictionary.Remove(lastNode.Value.InstanceUid);
        }

        public ImageDescription GetItem(string id) {
            if (!cacheDictionary.ContainsKey(id)) {
                return null;
            }
            var node = cacheDictionary[id];
            linkedList.Remove(node);
            linkedList.AddFirst(node);
            return node.Value;
        }
    }
}