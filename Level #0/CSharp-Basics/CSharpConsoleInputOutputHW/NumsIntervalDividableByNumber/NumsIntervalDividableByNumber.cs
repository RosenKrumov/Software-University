using System;

class NumsIntervalDividableByNumber
{
    static void Main()
    {
        //input
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());
        int p = 0;
        //logic
        for (int i = startNum; i <= endNum; i++)
        {
            if (i % 5 == 0)
            {
                p++;
            }
        }
        
        
        //output
        Console.WriteLine(p);
    }
}