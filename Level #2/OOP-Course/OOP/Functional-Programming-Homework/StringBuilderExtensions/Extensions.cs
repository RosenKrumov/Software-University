using System.Collections.Generic;
using System.Linq;

namespace StringBuilderExtensions
{
    using System;
    using System.Text;

    public static class Extensions
    {
        public static string Substring(this StringBuilder s, int start, int length)
        {
            if (length < 0 || start < 0)
            {
                throw new ArgumentException("Start index and end index must be positive.");
            }
            string stringBuilderAsString = s.ToString();
            string output = stringBuilderAsString.Substring(start, length);
            return output;
        }

        public static StringBuilder RemoveText(this StringBuilder s, string text)
        {
            int length = text.Length;
            string stringBuilderAsString = s.ToString();

            while (true)
            {
                int textPos = stringBuilderAsString.IndexOf(text, StringComparison.CurrentCultureIgnoreCase);

                if (textPos < 0)
                {
                    break;
                }

                stringBuilderAsString = stringBuilderAsString.Remove(textPos, length);
            }
            
            StringBuilder output = new StringBuilder(stringBuilderAsString);
            return output;
        }

        public static StringBuilder AppendAll<T>(this StringBuilder s, IEnumerable<T> items)
        {
            var result = items.Aggregate("", (current, item) => current + item.ToString());
            var output = s.Append(result);
            return output;
        }
    }
}
