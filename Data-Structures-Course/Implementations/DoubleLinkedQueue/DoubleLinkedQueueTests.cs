using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedQueue;

namespace DoubleLinkedQueueTests
{
    [TestClass]
    public class DoubleLinkedQueueTests
    {
        [TestMethod]
        public void TestPushPopElementShouldWorkCorrectly()
        {
            var numbers = new DoubleLinkedQueue<int>();
            Assert.AreEqual(0, numbers.Count);
            numbers.Enqueue(1);
            Assert.AreEqual(1, numbers.Count);
            var number = numbers.Dequeue();
            Assert.AreEqual(1, number);
        }

        [TestMethod]
        public void TestPushPopManyElementsShouldWorkCorrectly()
        {
            var strings = new DoubleLinkedQueue<string>();
            Assert.AreEqual(0, strings.Count);
            for (int i = 0; i < 1000; i++)
            {
                strings.Enqueue("Pesho");
                Assert.AreEqual(i + 1, strings.Count);
            }

            for (int i = 1000; i > 0; i--)
            {
                strings.Dequeue();
                Assert.AreEqual(i - 1, strings.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopElementShouldThrowException()
        {
            var queue = new DoubleLinkedQueue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        public void TestPushPopCheckValuesAndCountReturned()
        {
            var queue = new DoubleLinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);

            queue.Enqueue(12);
            Assert.AreEqual(1, queue.Count);

            queue.Enqueue(123);
            Assert.AreEqual(2, queue.Count);

            var element = queue.Dequeue();
            Assert.AreEqual(12, element);
            Assert.AreEqual(1, queue.Count);

            element = queue.Dequeue();
            Assert.AreEqual(123, element);
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void TestToArrayShouldWorkCorrectly()
        {
            var numbers = new DoubleLinkedQueue<int>();
            numbers.Enqueue(3);
            numbers.Enqueue(5);
            numbers.Enqueue(-2);
            numbers.Enqueue(7);
            var numbersArr = numbers.ToArray();
            var testArr = new[] { 3, 5, -2, 7 };
            CollectionAssert.AreEqual(testArr, numbersArr);
        }

        [TestMethod]
        public void TestEmptyStackToArrayShouldWorkCorrectly()
        {
            var dates = new DoubleLinkedQueue<DateTime>();
            var datesArr = dates.ToArray();
            Assert.AreEqual(0, datesArr.Length);
        }
    }
}
