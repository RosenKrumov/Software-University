using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Guitar : Instrument, IGuitar
    {
        public Guitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fingerboardWood, int numberOfStrings) 
            : base(make, model, price, color, isElectronic)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
            this.NumberOfStrings = numberOfStrings;
        }

        public string BodyWood { get; set; }

        public string FingerboardWood { get; set; }

        public int NumberOfStrings { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format("Strings: {0}\nBody wood: {1}\nFingerboard wood: {2}\n", this.NumberOfStrings,
                       this.BodyWood, this.FingerboardWood);
        }
    }
}
