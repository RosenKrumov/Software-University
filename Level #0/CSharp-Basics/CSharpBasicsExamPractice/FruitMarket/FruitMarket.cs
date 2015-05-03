using System;

class FruitMarket
{
    static void Main()
    {
        double banana = 1.80;
        double cucumber = 2.75;
        double tomato = 3.20;
        double orange = 1.60;
        double apple = 0.86;
        string dayOfWeek = Console.ReadLine();
        double quantity1 = double.Parse(Console.ReadLine());
        string product1 = Console.ReadLine();
        double quantity2 = double.Parse(Console.ReadLine());
        string product2 = Console.ReadLine();
        double quantity3 = double.Parse(Console.ReadLine());
        string product3 = Console.ReadLine();
        double sum = 0;

        if (dayOfWeek == "Friday")
        {
            banana = banana - banana / 10.0;
            cucumber = cucumber - cucumber / 10.0;
            tomato = tomato - tomato / 10.0;
            orange = orange - orange / 10.0;
            apple = apple - apple / 10.0;
            if (product1 == "banana")
            {
                sum += quantity1 * banana;
            }
            else if (product1 == "cucumber")
            {
                sum += quantity1 * cucumber;
            }
            else if (product1 == "tomato")
            {
                sum += quantity1 * tomato;
            }
            else if (product1 == "orange")
            {
                sum += quantity1 * orange;
            }
            else if (product1 == "apple")
            {
                sum += quantity1 * apple;
            }
            if (product2 == "banana")
            {
                sum += quantity2 * banana;
            }
            else if (product2 == "cucumber")
            {
                sum += quantity2 * cucumber;
            }
            else if (product2 == "tomato")
            {
                sum += quantity2 * tomato;
            }
            else if (product2 == "orange")
            {
                sum += quantity2 * orange;
            }
            else if (product2 == "apple")
            {
                sum += quantity2 * apple;
            }
            if (product3 == "banana")
            {
                sum += quantity3 * banana;
            }
            else if (product3 == "cucumber")
            {
                sum += quantity3 * cucumber;
            }
            else if (product3 == "tomato")
            {
                sum += quantity3 * tomato;
            }
            else if (product3 == "orange")
            {
                sum += quantity3 * orange;
            }
            else if (product3 == "apple")
            {
                sum += quantity3 * apple;
            }
            
        }
        else if (dayOfWeek == "Sunday")
        {
            banana = banana - banana / 20.0;
            cucumber = cucumber - cucumber / 20.0;
            tomato = tomato - tomato / 20.0;
            orange = orange - orange / 20.0;
            apple = apple - apple / 20.0;
            if (product1 == "banana")
            {
                sum += quantity1 * banana;
            }
            else if (product1 == "cucumber")
            {
                sum += quantity1 * cucumber;
            }
            else if (product1 == "tomato")
            {
                sum += quantity1 * tomato;
            }
            else if (product1 == "orange")
            {
                sum += quantity1 * orange;
            }
            else if (product1 == "apple")
            {
                sum += quantity1 * apple;
            }
            if (product2 == "banana")
            {
                sum += quantity2 * banana;
            }
            else if (product2 == "cucumber")
            {
                sum += quantity2 * cucumber;
            }
            else if (product2 == "tomato")
            {
                sum += quantity2 * tomato;
            }
            else if (product2 == "orange")
            {
                sum += quantity2 * orange;
            }
            else if (product2 == "apple")
            {
                sum += quantity2 * apple;
            }
            if (product3 == "banana")
            {
                sum += quantity3 * banana;
            }
            else if (product3 == "cucumber")
            {
                sum += quantity3 * cucumber;
            }
            else if (product3 == "tomato")
            {
                sum += quantity3 * tomato;
            }
            else if (product3 == "orange")
            {
                sum += quantity3 * orange;
            }
            else if (product3 == "apple")
            {
                sum += quantity3 * apple;
            }
        }
        else if (dayOfWeek == "Tuesday")
        {
            banana = banana - banana / 5.0;
            orange = orange - orange / 5.0;
            apple = apple - apple / 5.0;
            if (product1 == "banana")
            {
                sum += quantity1 * banana;
            }
            else if (product1 == "cucumber")
            {
                sum += quantity1 * cucumber;
            }
            else if (product1 == "tomato")
            {
                sum += quantity1 * tomato;
            }
            else if (product1 == "orange")
            {
                sum += quantity1 * orange;
            }
            else if (product1 == "apple")
            {
                sum += quantity1 * apple;
            }
            if (product2 == "banana")
            {
                sum += quantity2 * banana;
            }
            else if (product2 == "cucumber")
            {
                sum += quantity2 * cucumber;
            }
            else if (product2 == "tomato")
            {
                sum += quantity2 * tomato;
            }
            else if (product2 == "orange")
            {
                sum += quantity2 * orange;
            }
            else if (product2 == "apple")
            {
                sum += quantity2 * apple;
            }
            if (product3 == "banana")
            {
                sum += quantity3 * banana;
            }
            else if (product3 == "cucumber")
            {
                sum += quantity3 * cucumber;
            }
            else if (product3 == "tomato")
            {
                sum += quantity3 * tomato;
            }
            else if (product3 == "orange")
            {
                sum += quantity3 * orange;
            }
            else if (product3 == "apple")
            {
                sum += quantity3 * apple;
            }
        }
        else if (dayOfWeek == "Wednesday")
        {
            cucumber = cucumber - cucumber / 10.0;
            tomato = tomato - tomato / 10.0;
            if (product1 == "banana")
            {
                sum += quantity1 * banana;
            }
            else if (product1 == "cucumber")
            {
                sum += quantity1 * cucumber;
            }
            else if (product1 == "tomato")
            {
                sum += quantity1 * tomato;
            }
            else if (product1 == "orange")
            {
                sum += quantity1 * orange;
            }
            else if (product1 == "apple")
            {
                sum += quantity1 * apple;
            }
            if (product2 == "banana")
            {
                sum += quantity2 * banana;
            }
            else if (product2 == "cucumber")
            {
                sum += quantity2 * cucumber;
            }
            else if (product2 == "tomato")
            {
                sum += quantity2 * tomato;
            }
            else if (product2 == "orange")
            {
                sum += quantity2 * orange;
            }
            else if (product2 == "apple")
            {
                sum += quantity2 * apple;
            }
            if (product3 == "banana")
            {
                sum += quantity3 * banana;
            }
            else if (product3 == "cucumber")
            {
                sum += quantity3 * cucumber;
            }
            else if (product3 == "tomato")
            {
                sum += quantity3 * tomato;
            }
            else if (product3 == "orange")
            {
                sum += quantity3 * orange;
            }
            else if (product3 == "apple")
            {
                sum += quantity3 * apple;
            }
        }
        else if (dayOfWeek == "Thursday")
        {
            banana = banana - banana * 3.0 / 10.0;
            if (product1 == "banana")
            {
                sum += quantity1 * banana;
            }
            else if (product1 == "cucumber")
            {
                sum += quantity1 * cucumber;
            }
            else if (product1 == "tomato")
            {
                sum += quantity1 * tomato;
            }
            else if (product1 == "orange")
            {
                sum += quantity1 * orange;
            }
            else if (product1 == "apple")
            {
                sum += quantity1 * apple;
            }
            if (product2 == "banana")
            {
                sum += quantity2 * banana;
            }
            else if (product2 == "cucumber")
            {
                sum += quantity2 * cucumber;
            }
            else if (product2 == "tomato")
            {
                sum += quantity2 * tomato;
            }
            else if (product2 == "orange")
            {
                sum += quantity2 * orange;
            }
            else if (product2 == "apple")
            {
                sum += quantity2 * apple;
            }
            if (product3 == "banana")
            {
                sum += quantity3 * banana;
            }
            else if (product3 == "cucumber")
            {
                sum += quantity3 * cucumber;
            }
            else if (product3 == "tomato")
            {
                sum += quantity3 * tomato;
            }
            else if (product3 == "orange")
            {
                sum += quantity3 * orange;
            }
            else if (product3 == "apple")
            {
                sum += quantity3 * apple;
            }
        }
        else
        {
            if (product1 == "banana")
            {
                sum += quantity1 * banana;
            }
            else if (product1 == "cucumber")
            {
                sum += quantity1 * cucumber;
            }
            else if (product1 == "tomato")
            {
                sum += quantity1 * tomato;
            }
            else if (product1 == "orange")
            {
                sum += quantity1 * orange;
            }
            else if (product1 == "apple")
            {
                sum += quantity1 * apple;
            }
            if (product2 == "banana")
            {
                sum += quantity2 * banana;
            }
            else if (product2 == "cucumber")
            {
                sum += quantity2 * cucumber;
            }
            else if (product2 == "tomato")
            {
                sum += quantity2 * tomato;
            }
            else if (product2 == "orange")
            {
                sum += quantity2 * orange;
            }
            else if (product2 == "apple")
            {
                sum += quantity2 * apple;
            }
            if (product3 == "banana")
            {
                sum += quantity3 * banana;
            }
            else if (product3 == "cucumber")
            {
                sum += quantity3 * cucumber;
            }
            else if (product3 == "tomato")
            {
                sum += quantity3 * tomato;
            }
            else if (product3 == "orange")
            {
                sum += quantity3 * orange;
            }
            else if (product3 == "apple")
            {
                sum += quantity3 * apple;
            }
        }

        Console.WriteLine("{0:F2}", sum);

    }
}