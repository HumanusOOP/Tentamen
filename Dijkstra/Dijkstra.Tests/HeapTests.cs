using System;
using Dijkstra.Algorithm;
using NUnit.Framework;

namespace Dijkstra
{
    [TestFixture]
    public class HeapTests
    {
        [Test]
        public void TestAddOne()
        {

            //Arrange
            var sut = new Heap<int>(new MinStrategy<int>(new IntComparer()));

            //Act
            sut.Add(1);
            Assert.AreEqual(1, sut.RemoveMin());
        }

        [Test]
        public void TestAddTwoInReversedOrderButWithMaxStrategy()
        {
            var heap = new Heap<int>(new MaxStrategy<int>(new IntComparer()));
            heap.Add(1);
            heap.Add(2);
            Assert.AreEqual(2, heap.RemoveMin());
            Assert.AreEqual(1, heap.RemoveMin());
        }

        [Test]
        public void TestAddTwoInReversedOrderHeapNode()
        {
            var heap = new Heap<Node>(new MinStrategy<Node>(new HeapNodeComparer()));
            heap.Add(new Node('A') { Value = 1 });
            heap.Add(new Node('B') { Value = 2 });
            Assert.AreEqual("A", heap.RemoveMin().Name);
            Assert.AreEqual(2, heap.RemoveMin().Value);
        }

        [Test]
        public void TestAddTwoInOrder()
        {
            var heap = new Heap<int>(new MinStrategy<int>(new IntComparer()));
            heap.Add(1);
            heap.Add(2);
            var enumerator = heap.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(2, enumerator.Current);
        }

        [Test]
        public void TestAddTwoInReversedOrder()
        {
            var heap = new Heap<int>(new MinStrategy<int>(new IntComparer()));
            heap.Add(2);
            heap.Add(1);
            var enumerator = heap.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(2, enumerator.Current);
        }

        [Test]
        public void TestAddMultiple()
        {
            var heap = new Heap<int>(new MinStrategy<int>(new IntComparer()));
            heap.Add(2);
            heap.Add(7);
            heap.Add(4);
            heap.Add(6);
            heap.Add(5);
            heap.Add(3);
            heap.Add(1);
            Assert.AreEqual(1, heap.RemoveMin());
        }

        [Test]
        public void TestRemoveMin()
        {
            var heap = new Heap<int>(new MinStrategy<int>(new IntComparer()));
            heap.Add(2);
            heap.Add(7);
            heap.Add(4);
            heap.Add(6);
            heap.Add(5);
            heap.Add(3);
            heap.Add(1);
            Assert.AreEqual(1, heap.RemoveMin());
            Assert.AreEqual(2, heap.RemoveMin());
            Assert.AreEqual(3, heap.RemoveMin());
            Assert.AreEqual(4, heap.RemoveMin());
            Assert.AreEqual(5, heap.RemoveMin());
            Assert.AreEqual(6, heap.RemoveMin());
            Assert.AreEqual(7, heap.RemoveMin());
        }
   
        [Test]
        public void TestParentIndexOddChild()
        {
            Assert.AreEqual(2, 5.GetParentIndex());
        }

        [Test]
        public void TestParentIndexEvenChild()
        {
            Assert.AreEqual(2, 6.GetParentIndex());
        }

        [Test]
        public void TestParentIndex_RootIndexHasNoParent()
        {
            Assert.Throws<Exception>(() => 0.GetParentIndex());
        }

        [Test]

        public void TestChildrenIndices()
        {
            var indices = 0.GetChildrenIndices();
            Assert.AreEqual(1, indices.left);
            Assert.AreEqual(2, indices.right);

        }
    }
}
