namespace Sortable_Collection.HeapSortStructures
{
    using System;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly BinaryHeap<T> heap;

        public int Count
        {
            get { return this.heap.Count; }
        }

        public PriorityQueue()
        {
            this.heap = new BinaryHeap<T>();
        }

        public void Enqueue(T item)
        {
            this.heap.Add(item);
        }

        public T Dequeue()
        {
            return this.heap.Remove();
        }

        public void Peek()
        {
            this.heap.Peek();
        }

        public void Clear()
        {
            this.heap.Clear();
        }

        private void CopyAllElementsTo(T[] newArr)
        {
            this.heap.CopyTo(newArr);
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.heap.Count];
            this.CopyAllElementsTo(resultArr);
            return resultArr;
        }
    }
}
