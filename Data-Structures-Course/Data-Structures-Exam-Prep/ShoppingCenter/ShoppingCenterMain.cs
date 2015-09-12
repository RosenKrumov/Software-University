namespace ShoppingCenter
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class ShoppingCenterMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int commandsCount = int.Parse(Console.ReadLine());
            
            var center = new ShoppingManagerFast();
            
            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();
                var result = center.ProcessCommand(command);
                Console.WriteLine(result);
            }
        }
    }
}
