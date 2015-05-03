namespace GenericList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [Version(0, 1)]
    public class GenericList<T> where T : IComparable<T>
    {
        public const int CAPACITY = 16;

        private T[] inner;
        private int size;
        private int capacity;

        public GenericList(int capacity = CAPACITY)
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
            this.Inner[this.Size] = element;
            this.Size++;
        }
        
        public void Insert(T element, int position)
        {
            T[] newArr = new T[this.Capacity];

            Array.Copy(this.Inner, newArr, position);
            Array.Copy(new T[1] { element }, 0, newArr, position, 1);
            Array.Copy(this.Inner, position, newArr, position + 1, this.Inner.Length - position - 2);

            this.Inner = newArr;
            this.Size++;
        }

        public void Remove(int position)
        {
            T[] newArr = new T[this.Capacity];

            Array.Copy(this.Inner, newArr, position);
            Array.Copy(this.Inner, position + 1, newArr, position, this.Inner.Length - position - 1);

            this.Inner = newArr;
            this.Size--;
        }

        public void Clear()
        {
            this.Inner = new T[CAPACITY];
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this.Inner[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T element)
        {
            return this.Inner.Contains(element);
        }

        public T Min<B>()
        {
            return this.Inner.Min();
        }

        public T Max<B>()
        {
            return this.Inner.Max();
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

        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < this.Size; i++)
            {
                output += this.Inner[i];

                if (i != this.Size - 1)
                {
                    output += ", ";
                }
            }

            return output;
        }
    }
}
