using System.Collections;

namespace ReversedList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class ReversedList<T> : IEnumerable<T>
    {
        public const int CapacityConst = 16;
        private T[] inner;
        private int size;
        private int capacity;

        public ReversedList(int capacity = CapacityConst)
        {
            this.Inner = new T[this.Capacity];
            this.Size = 0;
            this.Capacity = capacity;
        }

        public T[] Inner
        {
            get
            {
                return this.inner;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Inner array cannot be null.");
                }
                this.inner = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Size must be positive.");
                }

                this.size = value;

                if (value >= this.Capacity)
                {
                    this.DoubleSize();
                }
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity must be positive.");
                }
                this.capacity = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.Size || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
                return this.Inner[index];
            }
            set
            {
                if (index >= this.Size || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
                this.Inner[index] = value;
            }
        }

        public void Add(T element)
        {
            this.Size++;
            for (int i = this.Inner.Length - 1; i >= 0; i++)
            {
                this.Inner[i + 1] = this.Inner[i];
            }
            this.Inner[0] = element;
        }

        public void Remove(int position)
        {
            T[] newArr = new T[this.Capacity];

            Array.Copy(this.Inner, newArr, position);
            Array.Copy(this.Inner, position + 1, newArr, position, this.Inner.Length - position - 1);

            this.Inner = newArr;
            this.Size--;
        }

        private void DoubleSize()
        {
            this.Capacity *= 2;
            T[] newArray = new T[this.Capacity];

            for (int i = 0; i < this.Size; i++)
            {
                newArray[i] = this.Inner[i];
            }

            this.Inner = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var index = 0;
            var currentElement = this.Inner[index];
            var length = this.Inner.Length;
            while (index <= length - 1)
            {
                yield return currentElement;
                index++;
                currentElement = this.Inner[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
