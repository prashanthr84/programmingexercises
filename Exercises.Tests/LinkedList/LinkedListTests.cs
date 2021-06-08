using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests.LinkedList {

    [TestClass]
    public class LinkedListTests {

        [TestMethod]
        public void ShouldAddAnElementToTheFirstPosition() {
            CustomLinkedList linkedList = new CustomLinkedList();
            CustomNode node = new CustomNode();
            node.Data = Guid.NewGuid().ToString();
            linkedList.AddFirst(node);
            CustomNode firstNode = linkedList.GetFirstNode();
            Assert.IsNotNull(firstNode);
            Assert.AreEqual(node.Data, firstNode.Data, "Incorrect data in the retrieved first node");
        }

        [TestMethod]
        public void ShouldAddAnElementToFirstPositionToExistingList() {
            CustomLinkedList linkedList = new CustomLinkedList();
            CustomNode firstNode = new CustomNode();
            firstNode.Data = Guid.NewGuid().ToString();
            linkedList.AddFirst(firstNode);

            CustomNode secondNode = new CustomNode();
            secondNode.Data = Guid.NewGuid().ToString();
            linkedList.AddFirst(secondNode);

            CustomNode thirdNode = new CustomNode();
            thirdNode.Data = Guid.NewGuid().ToString();
            linkedList.AddFirst(thirdNode);

            CustomNode retrievedFirstNode = linkedList.GetFirstNode();
            Assert.IsNotNull(retrievedFirstNode);
            Assert.AreEqual(firstNode.Data, retrievedFirstNode.Data, "Incorrect data in the retrieved first node");
        }

        [TestMethod]
        public void ShouldAddAnElementToTheLastPosition() {

        }

        [TestMethod]
        public void ShouldGetFirstNode() {

        }

        [TestMethod]
        public void ShouldGetLastNode() {

        }

    }

    public class CustomLinkedList {
        public CustomNode First { get; set; }

        public CustomNode Last { get; set; }

        public void AddFirst(CustomNode node)
        {
            First = node;
        }

        public CustomNode GetFirstNode()
        {
            return First;
        }
    }

    public class CustomNode
    {
        public string Data { get; set; }
    }
}
