using System;
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
            Assert.AreEqual(1, sut.DeleteMin());
        }

        [Test]
        public void TestAddTwoInReversedOrderButWithMaxStrategy()
        {
            var heap = new Heap<int>(new MaxStrategy<int>(new IntComparer()));
            heap.Add(1);
            heap.Add(2);
            Assert.AreEqual(2, heap.DeleteMin());
            Assert.AreEqual(1, heap.DeleteMin());
        }

        [Test]
        public void TestAddTwoInOrder()
        {
            var heap = new Heap<int>(new MinStrategy<int>(new IntComparer()));
            heap.Add(1);
            heap.Add(2);
            Assert.AreEqual(1, heap.DeleteMin());
            Assert.AreEqual(2, heap.DeleteMin());
        }

        [Test]
        public void TestAddTwoInReversedOrder()
        {
            var heap = new Heap<int>(new MinStrategy<int>(new IntComparer()));
            heap.Add(2);
            heap.Add(1);
            Assert.AreEqual(1, heap.DeleteMin());
            Assert.AreEqual(2, heap.DeleteMin());
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
            Assert.AreEqual(1, heap.DeleteMin());
        }
   
        [Test]
        public void TestParentIndexOddChild()
        {
            Assert.AreEqual(2, ArrayBackedBinaryTreeHelper.GetParentIndex(5));
        }

        [Test]
        public void TestParentIndexEvenChild()
        {
            Assert.AreEqual(2, ArrayBackedBinaryTreeHelper.GetParentIndex(6));
        }

        [Test]
        public void TestParentIndex_RootIndexHasNoParent()
        {
            Assert.Throws<Exception>(() => ArrayBackedBinaryTreeHelper.GetParentIndex(0));
            
        }
    }

    
}
