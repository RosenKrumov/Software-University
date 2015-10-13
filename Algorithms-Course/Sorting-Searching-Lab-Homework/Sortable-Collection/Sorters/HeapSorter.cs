namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using HeapSortStructures;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.HeapSort(collection);
        }

        private void HeapSort(List<T> collection)
        {
            var queue = new PriorityQueue<T>();
            collection.ForEach(t => queue.Enqueue(t));

            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = queue.Dequeue();
            }
        }
    }
}
