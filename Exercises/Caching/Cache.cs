using System.Collections.Generic;
using Exercises;
using Exercises.Caching;

namespace Cache {
    public class Cache {

        private readonly LinkedList<Image> linkedList;
        private Dictionary<string, LinkedListNode<Image>> cacheDictionary;
        private readonly int cacheSize = 10;

        public Cache(int cacheSize) {
            this.cacheSize = cacheSize;
            cacheDictionary = new Dictionary<string, LinkedListNode<Image>>(cacheSize);
            linkedList = new LinkedList<Image>();
        }

        public void PutItem(string key, Image value) {
            if (string.IsNullOrWhiteSpace(key)) {
                throw new InvalidCacheKeyException();
            }

            if(cacheDictionary.Count == cacheSize) {
                RemoveLeastRecentlyUsedItem();
            }

            if (!cacheDictionary.ContainsKey(key)) {
                LinkedListNode<Image> node = new LinkedListNode<Image>(value);
                linkedList.AddFirst(node);
                cacheDictionary.Add(key, node);
            }
        }

        private void RemoveLeastRecentlyUsedItem()  {
            var lastNode = linkedList.Last;
            linkedList.RemoveLast();
            cacheDictionary.Remove(lastNode.Value.InstanceUid);
        }

        public Image GetItem(string id) {
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