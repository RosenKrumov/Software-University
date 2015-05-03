using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Instrument : Article, IInstrument
    {
        public Instrument(string make, string model, decimal price, string color, bool isElectronic)
            : base(make, model, price)
        {
            this.Color = color;
            this.IsElectronic = isElectronic;
        }

        public string Color { get; set; }

        public bool IsElectronic { get; set; }

        public override string ToString()
        {
            string electronic = this.IsElectronic ? "yes" : "no";
            return base.ToString() + string.Format("Color: {0}\nElectronic: {1}\n", this.Color, electronic);
        }
    }
}
