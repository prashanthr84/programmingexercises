using System.Collections.Generic;
using Exercises;
using Exercises.Caching;

namespace Cache {
    public class Cache {

        private readonly int cacheSize = 10;
        DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
        Dictionary<string, Node> dictionaryDoublyLinkedList = new Dictionary<string, Node>();

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
                AddItemToCache(key, value);
            } else  {
                AddItemToCache(key, value);
            }
            // todo:// else simply add item to cache.
        }

        private void AddItemToCache(string key, ImageDescription value) {
            var node = doublyLinkedList.AddNewNodeAtHead(value, key);
            dictionaryDoublyLinkedList.Add(key, node);
        }

        private bool IsCacheFull() {
            //todo://
            return dictionaryDoublyLinkedList.Count == cacheSize;
        }

        private void RemoveLeastRecentlyUsedItem()  {
            var deletedNode = doublyLinkedList.DeleteNodeFromEnd();
            dictionaryDoublyLinkedList.Remove(deletedNode.Data.Key);
        }

        public ImageDescription GetItem(string id)  {
            //todo:// if the item present return the item else return null.
            if (dictionaryDoublyLinkedList.ContainsKey(id))
                return dictionaryDoublyLinkedList[id].Data.Value;
            return null;
        }
    }

    internal class DoublyLinkedList
    {
        internal Node HeadNode;
        internal Node TailNode;
        int size;
        public DoublyLinkedList()
        {
            HeadNode = null;
            size = 0;
        }
        public int GetLinkedListSize()
        {
            return size;
        }
        public Node AddNewNodeAtHead(ImageDescription value, string key)
        {
            if(HeadNode == null)
            {
                HeadNode = new Node();
                HeadNode.Previous = HeadNode.Next = null;
                HeadNode.Data = new ImageDescriptionData
                {
                    Key = key,
                    Value = value
                };
                TailNode = HeadNode;
                size++;
                return HeadNode;
            }
            var temp = HeadNode;
            HeadNode = new Node();
            HeadNode.Previous = null;
            HeadNode.Next = temp;
            HeadNode.Data = new ImageDescriptionData
            {
                Key = key,
                Value = value
            };
            temp.Previous = HeadNode;
            if (size == 1)
                TailNode = temp;
            size++;
            return HeadNode;
        }
        public void BringNodeToFront()
        {

        }

        public Node DeleteNodeFromEnd()
        {
            var temp = TailNode;
            TailNode = temp.Previous;
            temp.Previous.Next = TailNode.Next = null;
            size--;
            return temp;
        }
    }

    internal class Node
    {
        internal Node Previous { get; set; }
        internal Node Next { get; set; }
        internal ImageDescriptionData Data { get; set; }
    }

    internal class ImageDescriptionData
    {
        internal string Key { get; set; }
        internal ImageDescription Value { get; set; }
    }
}