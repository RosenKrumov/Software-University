namespace NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursion
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            GenerateNumbers(n, array);
        }

        public static void GenerateNumbers(int n, int[] array, int index = 0)
        {
            if (index == array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    array[index] = i;
                    GenerateNumbers(n, array, index + 1);
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
