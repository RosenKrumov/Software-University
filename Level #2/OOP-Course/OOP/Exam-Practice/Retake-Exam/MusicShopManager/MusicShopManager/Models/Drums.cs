using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Drums : Instrument, IDrums
    {
        public Drums(string make, string model, decimal price, string color, bool isElectronic, int width, int height) 
            : base(make, model, price, color, isElectronic)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format("Size: {0}cm x {1}cm", this.Width, this.Height);
        }
    }
}
