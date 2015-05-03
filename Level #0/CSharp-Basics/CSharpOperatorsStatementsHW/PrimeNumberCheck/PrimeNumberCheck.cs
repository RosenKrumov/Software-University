using System;

class PrimeNumberCheck
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n <= 1)
        {
            Console.WriteLine("False");
            return;
        }
        bool prime = true;
        for (int i = 2; i <= n-1; i++)
        {
            if (n % i == 0)
            {
                prime = false;
            }
            
        }
        Console.WriteLine(prime);
    }
}