namespace Scoreboard
{
    using System;

    public class ScoreboardMain
    {
        static void Main()
        {
            var command = "";
            var system = new Scoreboard();
            do
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    return;
                }

                if (string.IsNullOrEmpty(command))
                {
                    continue;
                }
                var result = system.ProcessCommand(command);
                Console.WriteLine(result);
            } while (command != "End");
        }
    }
}
