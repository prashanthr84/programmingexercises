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

        public void AddItem(ImageDescription item) {
            if (string.IsNullOrWhiteSpace(item.Id)) {
                throw new InvalidCacheKeyException();
            }

            if(cacheDictionary.Count == cacheSize) {
                RemoveLeastRecentlyUsedItem();
            }

            if (cacheDictionary.ContainsKey(item.Id)) {
                // update node ?
                // Move the node to the front of the linked list


            } else  {
                LinkedListNode<ImageDescription> node = new LinkedListNode<ImageDescription>(item);
                linkedList.AddFirst(node);
                cacheDictionary.Add(item.Id, node);
            }
        }

        private void RemoveLeastRecentlyUsedItem()  {
            var lastNode = linkedList.Last;
            linkedList.RemoveLast();
            cacheDictionary.Remove(lastNode.Value.Id);
        }

        public ImageDescription TryGetItem(string id) {
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