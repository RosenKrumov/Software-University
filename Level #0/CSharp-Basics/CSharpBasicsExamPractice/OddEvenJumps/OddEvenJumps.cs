using System;

class OddEvenJumps
{
    static void Main()
    {
        string input = Console.ReadLine();
        string inputLower = input.ToLower().Replace(" ", string.Empty);
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());
        int oddJumpInc = oddJump;
        int evenJumpInc = evenJump;
        long oddResult = 0L;
        long evenResult = 0L;
        for (int i = 0; i < inputLower.Length; i += 2)
        {
            if (i == oddJump * 2 - 2)
            {
                oddResult *= (int)inputLower[i];
                oddJump += oddJumpInc;
            }

            else
            {
                oddResult += (int)inputLower[i];
            }
            
        }

        for (int i = 1; i < inputLower.Length; i += 2)
        {
            if (i == evenJump * 2 - 1)
            {
                int incValue = (int)inputLower[i];
                evenResult *= (int)inputLower[i];
                evenJump += evenJumpInc;
            }

            else
            {
                evenResult += (int)inputLower[i];
            }
        }

        Console.WriteLine("Odd: {0:X}", oddResult);
        Console.WriteLine("Even: {0:X}", evenResult);

    }
}