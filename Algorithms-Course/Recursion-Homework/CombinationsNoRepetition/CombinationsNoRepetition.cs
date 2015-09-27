namespace CombinationsNoRepetition
{
    using System;

    public class CombinationsNoRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];

            GenerateCombinations(array, n);
        }

        private static void GenerateCombinations(int[] array, int n, int index = 0, int start = 1)
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
                    GenerateCombinations(array, n, index + 1, i + 1);
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}
