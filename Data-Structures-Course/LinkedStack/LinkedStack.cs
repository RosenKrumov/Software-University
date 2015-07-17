using System;

namespace LinkedStack
{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;
        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            var outputElement = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return outputElement;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            var index = 0;
            while (this.Count > 0)
            {
                resultArr[index] = this.Pop();
                index++;
            }

            return resultArr;
        }

        private class Node<T>
        {
            private T value;

            public T Value { get; private set; }

            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            } 
        }
    }

    public class Test
    {
        static void Main()
        {
            
        }
    }
}
