namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = collection[start];
            var storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    Swap(collection, i, storeIndex);
                    storeIndex++;
                }
            }

            storeIndex--;
            Swap(collection, start, storeIndex);
            QuickSort(collection, start, storeIndex - 1);
            QuickSort(collection, storeIndex + 1, end);
        }

        private static void Swap(IList<T> collection, int a, int b)
        {
            var buffer = collection[a];
            collection[a] = collection[b];
            collection[b] = buffer;
        }
    }
}
