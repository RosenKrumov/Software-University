using System;
using Wintellect.PowerCollections;

namespace ProductsPriceRange
{
    public class ProductsPriceRange
    {
        static void Main()
        {
            var products = new OrderedMultiDictionary<decimal, string>(true);
            int productsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < productsCount; i++)
            {
                var line = Console.ReadLine();
                var tokens = line.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                var product = tokens[0].Trim();
                var price = decimal.Parse(tokens[1].Trim());
                products.Add(price, product);
            }

            var priceRange = Console.ReadLine();
            var priceTokens = priceRange.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
            var startPrice = decimal.Parse(priceTokens[0].Trim());
            var endPrice = decimal.Parse(priceTokens[1].Trim());

            var productsRange = products.Range(startPrice, true, endPrice, true);
            foreach (var pair in productsRange)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, string.Join(", ", pair.Value));
            }
        }
    }
}
