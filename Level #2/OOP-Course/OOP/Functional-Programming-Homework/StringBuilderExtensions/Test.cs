namespace StringBuilderExtensions
{
    using System;
    using System.Text;

    public class Test
    {
        static void Main()
        {
            StringBuilder strBuilder = new StringBuilder("SoftUni");
            string separated = strBuilder.Substring(2, 4);
            Console.WriteLine(separated);

            StringBuilder secondStrBuilder = new StringBuilder("Software University");
            StringBuilder removed = secondStrBuilder.RemoveText("Software");
            Console.WriteLine(removed);

            StringBuilder thirdStrBuilder = new StringBuilder("Software University");
            StringBuilder appendedStrBuilder = thirdStrBuilder.AppendAll(new string[] {"softuni", "SOFTUNI"});
            Console.WriteLine(appendedStrBuilder);
        }
    }
}
