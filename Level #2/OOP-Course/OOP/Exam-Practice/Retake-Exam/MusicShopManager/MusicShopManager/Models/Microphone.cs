using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Microphone : Article, IMicrophone
    {
        public Microphone(string make, string model, decimal price, bool hasCable) 
            : base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable { get; set; }

        public override string ToString()
        {
            string cable = this.HasCable ? "yes" : "no";
            return base.ToString() + string.Format("Cable: {0}", cable);
        }
    }
}
