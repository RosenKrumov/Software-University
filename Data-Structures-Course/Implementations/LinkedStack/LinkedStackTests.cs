using System;
using LinkedStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedStackTests
{
    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void TestPushPopElementShouldWorkCorrectly()
        {
            var numbers = new LinkedStack<int>();
            Assert.AreEqual(0, numbers.Count);
            numbers.Push(1);
            Assert.AreEqual(1, numbers.Count);
            var number = numbers.Pop();
            Assert.AreEqual(1, number);
        }

        [TestMethod]
        public void TestPushPopManyElementsShouldWorkCorrectly()
        {
            var strings = new LinkedStack<string>();
            Assert.AreEqual(0, strings.Count);
            for (int i = 0; i < 1000; i++)
            {
                strings.Push("Pesho");
                Assert.AreEqual(i + 1, strings.Count);
            }

            for (int i = 1000; i > 0; i--)
            {
                strings.Pop();
                Assert.AreEqual(i - 1, strings.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopElementShouldThrowException()
        {
            var stack = new LinkedStack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void TestPushPopCheckValuesAndCountReturned()
        {
            var stack = new LinkedStack<int>();
            Assert.AreEqual(0, stack.Count);

            stack.Push(12);
            Assert.AreEqual(1, stack.Count);

            stack.Push(123);
            Assert.AreEqual(2, stack.Count);

            var element = stack.Pop();
            Assert.AreEqual(123, element);
            Assert.AreEqual(1, stack.Count);

            element = stack.Pop();
            Assert.AreEqual(12, element);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestToArrayShouldWorkCorrectly()
        {
            var numbers = new LinkedStack<int>();
            numbers.Push(3);
            numbers.Push(5);
            numbers.Push(-2);
            numbers.Push(7);
            var numbersArr = numbers.ToArray();
            var testArr = new[] { 7, -2, 5, 3 };
            CollectionAssert.AreEqual(testArr, numbersArr);
        }

        [TestMethod]
        public void TestEmptyStackToArrayShouldWorkCorrectly()
        {
            var dates = new LinkedStack<DateTime>();
            var datesArr = dates.ToArray();
            Assert.AreEqual(0, datesArr.Length);
        }
    }
}
