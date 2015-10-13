namespace Sortable_Collection.HeapSortStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryHeap<T> : IEnumerable where T : IComparable<T>
    {
        private const int DefaultSize = 8;

        private T[] data = new T[DefaultSize];
        private int count;
        private int capacity = DefaultSize;
        private bool sorted;

        public BinaryHeap()
        {
        }

        public BinaryHeap(T[] data, int count)
        {
            this.Capacity = count;
            this.count = count;
            Array.Copy(data, this.data, count);
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                int previousCapacity = this.capacity;
                this.capacity = Math.Max(value, this.count);
                if (this.capacity != previousCapacity)
                {
                    T[] temp = new T[this.capacity];
                    Array.Copy(this.data, temp, this.count);
                    this.data = temp;
                }
            }
        }

        public T Peek()
        {
            return this.data[0];
        }

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity *= 2;
            }

            this.data[this.Count] = item;
            this.UpHeap();
            this.Count++;
        }

        private void UpHeap()
        {
            this.sorted = false;
            int p = this.Count;
            T item = this.data[p];
            int parent = this.GetParentIndex(p);

            while (parent != -1 && p > -1 && item.CompareTo(this.data[parent]) < 0)
            {
                this.data[p] = this.data[parent];
                p = parent;
                parent = this.GetParentIndex(p);
            }

            this.data[p] = item;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) >> 1;
        }

        private int GetFirstChildIndex(int index)
        {
            return (index << 1) + 1;
        }

        private int GetSecondChildIndex(int index)
        {
            return (index << 1) + 2;
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new T[this.Capacity];
        }

        public void CopyTo(T[] array, int arrayIndex = 0)
        {
            this.SortHeap();
            Array.Copy(this.data, array, this.Count);
        }

        public T Remove()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }
            T value = this.data[0];
            this.Count--;
            this.data[0] = this.data[this.Count];
            this.data[this.Count] = default(T);
            this.DownHeap();
            return value;
        }

        private void DownHeap()
        {
            this.sorted = false;
            int n;
            int p = 0;
            T item = this.data[p];
            while (true)
            {
                int firstChildIndex = this.GetFirstChildIndex(p);
                if (firstChildIndex >= this.Count)
                {
                    break;
                }

                int secondChildIndex = this.GetSecondChildIndex(p);
                if (secondChildIndex >= this.Count)
                {
                    n = firstChildIndex;
                }
                else
                {
                    n = this.data[firstChildIndex].CompareTo(this.data[secondChildIndex]) < 0
                        ? firstChildIndex
                        : secondChildIndex;
                }

                if (item.CompareTo(this.data[n]) > 0)
                {
                    this.data[p] = this.data[n];
                    p = n;
                }
                else
                {
                    break;
                }
            }

            this.data[p] = item;
        }

        private void SortHeap()
        {
            if (this.sorted)
            {
                return;
            }

            Array.Sort(this.data, 0, this.Count);
            this.sorted = true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.SortHeap();
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
