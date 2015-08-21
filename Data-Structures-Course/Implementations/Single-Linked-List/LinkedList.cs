using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        private class ListNode<T>
        {
            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }
        }

        private ListNode<T> head;

        private ListNode<T> tail; 

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                this.tail.NextNode = newTail;
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException("Index is out of bounds of the list");    
            }

            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var currentIndex = 0;
            var currentElement = this.head;
            while (currentIndex < index - 1)
            {
                currentElement = currentElement.NextNode;
                currentIndex++;
            }

            if (index == 0)
            {
                this.head = this.head.NextNode;
                this.Count--;
            }
            else if (index == this.Count - 1)
            {
                this.tail = currentElement;
                currentElement.NextNode = null;
            }
            else
            {
                currentElement.NextNode = currentElement.NextNode.NextNode;
                this.Count--;
            }
        }

        public int FirstIndexOf(T element)
        {
            var currentElement = this.head;
            var index = 0;
            while (currentElement != null && !currentElement.Value.Equals(element))
            {
                index++;
                currentElement = currentElement.NextNode;
            }

            if (index > this.Count - 1)
            {
                index = -1;
            }

            return index;
        }

        public int LastIndexOf(T element)
        {
            int index = -1;
            int counter = 0;

            foreach (T item in this)
            {
                if (item.Equals(element))
                {
                    index = counter;
                }

                counter++;
            }

            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
