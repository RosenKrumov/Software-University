namespace BiDictionary
{
    using System;

    public class PlayWithBiDictionary
    {
        public static void Main()
        {
            var distances = new BiDictionary<string, string, int>();
            distances.Add("Sofia", "Varna", 443);
            distances.Add("Sofia", "Varna", 468);
            distances.Add("Sofia", "Varna", 490);
            distances.Add("Sofia", "Plovdiv", 145);
            distances.Add("Sofia", "Bourgas", 383);
            distances.Add("Plovdiv", "Bourgas", 253);
            distances.Add("Plovdiv", "Bourgas", 292);
            var distancesFromSofia = distances.FindByFirstKey("Sofia");// [443, 468, 490, 145, 383]
            Console.WriteLine("[{0}]", string.Join(", ", distancesFromSofia));
            var distancesToBourgas = distances.FindBySecondKey("Bourgas"); // [383, 253, 292]
            Console.WriteLine("[{0}]", string.Join(", ", distancesToBourgas));
            var distancesPlovdivBourgas = distances.FindByCompositeKey("Plovdiv", "Bourgas"); // [253, 292]
            Console.WriteLine("[{0}]", string.Join(", ", distancesPlovdivBourgas));
            var distancesRousseVarna = distances.FindByCompositeKey("Rousse", "Varna"); // []
            Console.WriteLine("[{0}]", string.Join(", ", distancesRousseVarna));
            var distancesSofiaVarna = distances.FindByCompositeKey("Sofia", "Varna"); // [443, 468, 490]
            Console.WriteLine("[{0}]", string.Join(", ", distancesSofiaVarna));
            Console.WriteLine(distances.Remove("Sofia", "Varna")); // true
            var distancesFromSofiaAgain = distances.FindByFirstKey("Sofia"); // [145, 383]
            Console.WriteLine("[{0}]", string.Join(", ", distancesFromSofiaAgain));
            var distancesToVarna = distances.FindBySecondKey("Varna"); // []
            Console.WriteLine("[{0}]", string.Join(", ", distancesToVarna));
            var distancesSofiaVarnaAgain = distances.FindByCompositeKey("Sofia", "Varna"); // []
            Console.WriteLine("[{0}]", string.Join(", ", distancesSofiaVarnaAgain));
        }
    }
}
