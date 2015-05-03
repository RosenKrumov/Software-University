using System;

class NumAsWords
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());

        string[] ones = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        string[] tenToTwenty = {"", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] tens = {"", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        string[] hundreds = {"", "One hundred", "Two hundred", "Three hundred", "Four hundred", "Five hundred", "Six hundred", "Seven hundred", "Eight hundred", "Nine hundred" };

        if (num == 0)
        {
            Console.WriteLine("Zero");    
        }

        if (num < 10)
        {
            for (int i = 1; i <= 9; i++)
            {
                if (i == num)
                {
                    Console.WriteLine(ones[i]);    
                }
                
            }    
        }

        if (num >= 10 && num < 20)
        {
            for (int i = 10; i < 20; i++)
            {
                if (i == num)
                {
                    Console.WriteLine(tenToTwenty[i % 10]);
                }
                    
            }    
        }

        if (num >= 20 && num < 100)
        {
            for (int i = 20; i < 100; i++)
            {
                if (num == i)
                {
                    Console.Write(tens[i/10] + " ");
                    Console.WriteLine(ones[i % 10]);
                }
            }
        }

        if (num >= 100 && num < 1000)
        {
            for (int i = 100; i < 1000; i++)
            {
                if ((num == i) && (num/10%10 == 1))
                {
                    Console.Write(hundreds[i / 100] + " and ");
                    Console.WriteLine(tenToTwenty[i % 100 - 9]);
                   
                    
                }

                else if (num == i && num % 100 != 0)
                {
                    Console.Write(hundreds[i / 100] + " and ");
                    Console.Write(tens[(i / 10) % 10] + " ");
                    Console.WriteLine(ones[(i % 10)]);
                }


                else if (num == i && num % 100 == 0)
                {
                    Console.WriteLine(hundreds[i/100]);
                }
            }
        }
        
    }
}