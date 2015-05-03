using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class BassGuitar : Guitar, IBassGuitar
    {
        public BassGuitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fingerboardWood, int numberOfStrings) 
            : base(make, model, price, color, isElectronic, bodyWood, fingerboardWood, numberOfStrings)
        {
        }
    }
}
