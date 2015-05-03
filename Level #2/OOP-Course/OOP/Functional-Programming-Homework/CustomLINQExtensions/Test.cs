using System.Linq;

namespace CustomLINQExtensions
{
    using System;
    using System.Collections.Generic;

    public class Test
    {
        static void Main()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5,6,7
            };

            var filteredList = list.WhereNot(num => num%2 == 0).ToList();
            filteredList.ForEach(num => Console.WriteLine(num));

            List<string> stringList = new List<string>()
            {
                "pesho",
                "gosho",
                "misho"
            };

            var repeatedStringList = stringList.Repeat(3);
            repeatedStringList.ToList().ForEach(str => Console.WriteLine(str));

            List<string> unis = new List<string>()
            {
                "Softuni",
                "Harduni",
                "Niceuni",
                "CoolUni"
            };

            var filteredUnis = unis.WhereEndsWith(new List<string>() {"uni", "Soft", "12093"});
            filteredUnis.ToList().ForEach(uni => Console.WriteLine(uni));
        }
    }
}
