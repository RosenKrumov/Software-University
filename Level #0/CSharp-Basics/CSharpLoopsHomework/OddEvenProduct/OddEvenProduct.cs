using System;

class OddEvenProduct
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int[] inputInt = new int[input.Length];
        int oddProduct = 1;
        int evenProduct = 1;

        for (int i = 0; i < input.Length; i++)
        {
            inputInt[i] = Convert.ToInt32(input[i].ToString());
        }

        for (int i = 0; i < inputInt.Length; i+=2)
        {
            oddProduct *= inputInt[i];
        }
        
        for (int i = 1; i < inputInt.Length; i+=2)
        {
            evenProduct *= inputInt[i];
        }

        if (oddProduct == evenProduct)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = {0}", oddProduct);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = {0}", oddProduct);
            Console.WriteLine("even_product = {0}", evenProduct);
        }
    }
}