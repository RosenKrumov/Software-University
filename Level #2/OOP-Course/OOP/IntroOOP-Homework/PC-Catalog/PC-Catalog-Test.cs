using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Component processorIntel = new Component("Intel Core i7", "1.8Ghz", 280.55M);
        Component processorAMD = new Component("AMD X8", "3.0Ghz", 500M);

        Component graphicsNVidia = new Component("GeForce 720M", "2GB GDDR5", 450M);
        Component graphicsATI = new Component("Radeon HD5975", "4GB GDDR5", 760M);
        //Component graphics = new Component("", 102M);
        //Component graphics = new Component("asd", -102M);

        Component ramCheep = new Component("Kingston", "4GB DDR3", 100M);
        Component ramExpensive = new Component("Kingston", "16GB DDR3", 250M);

        Computer firstComp = new Computer("ACER", ramCheep, processorIntel, graphicsNVidia);
        Computer secondComp = new Computer("China", ramExpensive, processorAMD, graphicsATI);
        Computer thirdComp = new Computer("Pichko", ramExpensive, processorIntel, graphicsATI);

        //Console.WriteLine(); //-------> Choose what to test.

        var computers = new List<Computer>();
        computers.Add(firstComp);
        computers.Add(secondComp);
        computers.Add(thirdComp);

        computers.OrderBy(computer => computer.TotalPrice).ToList().ForEach(computer => Console.WriteLine(computer));
    }
}