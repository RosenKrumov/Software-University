using System.Collections.Specialized;
using MusicShopManager.Interfaces;
using MusicShopManager.Models;

namespace MusicShop.Models
{
    public class AcousticGitar : Guitar, IAcousticGuitar
    {
        public AcousticGitar(string make, string model, decimal price, string color, bool isElectronic,
            string bodyWood, string fingerboardWood, int numberOfStrings, bool caseIncluded, StringMaterial stringMaterial) 
            : base(make, model, price, color, isElectronic, bodyWood, fingerboardWood, numberOfStrings)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded { get; set; }

        public StringMaterial StringMaterial { get; set; }

        public override string ToString()
        {
            string caseIncluded = this.CaseIncluded ? "yes" : "no";
            return base.ToString() +
                   string.Format("Case included: {0}\nString material: {1}", caseIncluded, this.StringMaterial);
        }
    }
}
