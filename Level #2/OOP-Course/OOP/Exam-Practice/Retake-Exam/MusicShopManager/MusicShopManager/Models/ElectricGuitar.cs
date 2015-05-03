using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        public ElectricGuitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood,
            string fingerboardWood, int numberOfStrings, int numberOfAdapters, int numberOfFrets) 
            : base(make, model, price, color, isElectronic, bodyWood, fingerboardWood, numberOfStrings)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
        }

        public int NumberOfAdapters { get; set; }

        public int NumberOfFrets { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format("Adapters: {0}\nFrets: {1}", this.NumberOfAdapters, this.NumberOfFrets);
        }
    }
}
