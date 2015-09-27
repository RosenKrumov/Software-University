namespace CombinationsWithRepetition
{
    using System;

    public class CombinationsWithRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];

            GenerateCombinations(n, array);
        }

        private static void GenerateCombinations(int n, int[] array, int index = 0, int start = 1)
        {
            if (index == array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    array[index] = i;
                    GenerateCombinations(n, array, index + 1, i);
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}
