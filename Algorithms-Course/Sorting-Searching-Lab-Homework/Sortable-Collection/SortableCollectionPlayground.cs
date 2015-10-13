namespace Sortable_Collection
{
    using System;
    using Sorters;

    public class SortableCollectionPlayground
    {
        private static readonly Random Random = new Random();

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 100;
            const int MaxValue = 999;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter { Max = MaxValue });

            //Console.WriteLine(collectionToSort);

            var collection = new SortableCollection<int>(2, -1, 5, 0, -3);
            //Console.WriteLine(collection);

            collection.Sort(new HeapSorter<int>());
            //Console.WriteLine(collection);

            var collectionToShuffle = new SortableCollection<int>(1, 2, 3, 4, 5);
            Console.WriteLine(collectionToShuffle);
            collectionToShuffle.Shuffle();
            Console.WriteLine(collectionToShuffle);

            Console.WriteLine("----------------------------");

            collectionToShuffle = new SortableCollection<int>(1, 3, 5, 7, 9, 20, 25, 50);
            Console.WriteLine(collectionToShuffle);
            collectionToShuffle.Shuffle();
            Console.WriteLine(collectionToShuffle);

            Console.WriteLine("----------------------------");

            collectionToShuffle = new SortableCollection<int>(1, 100, 1000, 100000);
            Console.WriteLine(collectionToShuffle);
            collectionToShuffle.Shuffle();
            Console.WriteLine(collectionToShuffle);

            Console.WriteLine("----------------------------");

            collectionToShuffle = new SortableCollection<int>(1, 2, 3);
            Console.WriteLine(collectionToShuffle);
            collectionToShuffle.Shuffle();
            Console.WriteLine(collectionToShuffle);
        }
    }
}
