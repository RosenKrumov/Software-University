namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var temp = new T[collection.Count];
            this.MergeSort(collection, temp, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> collection, T[] temp, int start, int end)
        {
            if (start < end)
            {
                int middle = start + (end - start)/2;

                MergeSort(collection, temp, start, middle);
                MergeSort(collection, temp, middle + 1, end);

                Merge(collection, temp, start, end, middle);
            }
        }

        private static void Merge(List<T> collection, T[] temp, int start, int end, int middle)
        {
            int leftMinIndex = start;
            int rightMinIndex = middle + 1;
            int tempIndex = 0;

            while (leftMinIndex <= middle && rightMinIndex <= end)
            {
                if (collection[leftMinIndex].CompareTo(collection[rightMinIndex]) <= 0)
                {
                    temp[tempIndex] = collection[leftMinIndex];
                    leftMinIndex++;
                }
                else
                {
                    temp[tempIndex] = collection[rightMinIndex];
                    rightMinIndex++;
                }

                tempIndex++;
            }

            while (leftMinIndex <= middle)
            {
                temp[tempIndex] = collection[leftMinIndex];
                tempIndex++;
                leftMinIndex++;
            }

            while (rightMinIndex <= end)
            {
                temp[tempIndex] = collection[rightMinIndex];
                tempIndex++;
                rightMinIndex++;
            }

            tempIndex = 0;
            leftMinIndex = start;

            while (tempIndex < temp.Length && leftMinIndex <= end)
            {
                collection[leftMinIndex] = temp[tempIndex];
                leftMinIndex++;
                tempIndex++;
            }
        }
    }
}
