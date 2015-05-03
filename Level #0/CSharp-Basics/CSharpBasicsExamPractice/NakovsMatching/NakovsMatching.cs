using System;

class NakovsMatching
{
    static void Main()
    {
        string firstWord = Console.ReadLine();
        string secondWord = Console.ReadLine();
        int d = int.Parse(Console.ReadLine());
        int matchings = 0;

        for (int i = 0; i < firstWord.Length; i++)
        {
            for (int j = 0; j < secondWord.Length; j++)
            {
                int subFirstLeftSum = 0;
                int subFirstRightSum = 0;
                int subSecondLeftSum = 0;
                int subSecondRightSum = 0;
                int sum = 0;
                string subFirstLeft = firstWord.Substring(0, i + 1);
                string subFirstRight = firstWord.Substring(i + 1, firstWord.Length - (i + 1));
                string subSecondLeft = secondWord.Substring(0, j + 1);
                string subSecondRight = secondWord.Substring(j + 1,secondWord.Length - (j + 1));
                if (subFirstRight.Length == 0 || subSecondRight.Length == 0)
                {
                    continue;
                }

                for (int k = 0; k < subFirstLeft.Length; k++)
                {
                    subFirstLeftSum += (int)subFirstLeft[k];
                }

                for (int g = 0; g < subFirstRight.Length; g++)
                {
                    subFirstRightSum += (int)subFirstRight[g];
                }

                for (int c = 0; c < subSecondLeft.Length; c++)
                {
                    subSecondLeftSum += (int)subSecondLeft[c];
                }

                for (int b = 0; b < subSecondRight.Length; b++)
                {
                    subSecondRightSum += (int)subSecondRight[b];
                }
                sum = Math.Abs(subFirstLeftSum * subSecondRightSum - subFirstRightSum * subSecondLeftSum); 
                if (sum <= d)
                {
                    matchings++;
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs", subFirstLeft, subFirstRight, subSecondLeft, subSecondRight, sum);
                }
                
            }
        }
        if (matchings == 0)
        {
            Console.WriteLine("No");
        }
        
    }
}