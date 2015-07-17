using System;

namespace ArrayBasedStack
{
    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }

        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            this.Count--;
            return this.elements[this.Count];
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

        private void Grow()
        {
            var newElements = new T[this.elements.Length*2];
            this.CopyAllElementsTo(newElements);
            this.elements = newElements;
        }

        private void CopyAllElementsTo(T[] newElements)
        {
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
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
