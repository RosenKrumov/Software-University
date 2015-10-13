namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; private set; }

        public int Count {get { return this.Items.Count; }}

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            var index = this.BinarySearchProcedure(item, 0, this.Count - 1);
            return index;
        }

        public int InterpolationSearch(T item)
        {
            var items = this.Items.Select(t => Convert.ToInt32(t)).ToList();
            var index = this.InterpolationSearchProcedure(items, Convert.ToInt32(item));
            return index;
        }

        public void Shuffle()
        {
            this.ShuffleProcedure(this.Items);
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", this.Items));
        }

        private void ShuffleProcedure(IList<T> items)
        {
            var random = new Random();
            var n = items.Count;

            for (int i = 0; i < n; i++)
            {
                int randomIndex = i + random.Next(0, n - i);
                var temp = items[i];
                items[i] = items[randomIndex];
                items[randomIndex] = temp;
            }
        }

        private int InterpolationSearchProcedure(List<int> items , int item)
        {
            int low = 0;
            int high = this.Items.Count - 1;

            if (items.Count == 0)
            {
                return -1;
            }

            while (items[low].CompareTo(item) <= 0 && items[high].CompareTo(item) >= 0)
            {
                int mid = low + ((item - items[low])*(high - low))/(items[high] - items[low]);

                if (items[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else if (items[mid].CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (items[low].CompareTo(item) == 0)
            {
                return low;
            }
            else
            {
                return -1;
            }
        }

        private int BinarySearchProcedure(T item, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = start + (end - start) / 2;

            if (this.Items[mid].CompareTo(item) > 0)
            {
                return BinarySearchProcedure(item, start, mid - 1);
            }

            if (this.Items[mid].CompareTo(item) < 0)
            {
                return BinarySearchProcedure(item, mid + 1, end);
            }
            
            return mid;
        }
    }
}