using System;
using System.Collections.Generic;

    class PrimesGivenRange
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            List<int> numbers = FindPrimesInRange(start, end);
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                Console.Write(numbers[i]);
                Console.Write(", ");
            }
            Console.WriteLine(numbers[numbers.Count - 1]);
        }

        static List<int> FindPrimesInRange (int start, int end)
        {
            List<int> numbers = new List<int>();
            bool prime = true;
            for (int i = start; i <= end; i++)
            {
                if (i <= 1)
                {
                    prime = false;
                }
                else
                {
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i % j == 0)
                        {
                            prime = false;
                        }
                    }
                }

                if (prime == true)
                {
                    numbers.Add(i);
                }
                prime = true;
                
            }
            return numbers;
        }
    }