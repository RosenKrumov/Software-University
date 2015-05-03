using MusicShop.Models;

namespace MusicShopManager.Engine.Factories
{
    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class ArticleFactory : IArticleFactory
    {
        public IMicrophone CreateMirophone(string make, string model, decimal price, bool hasCable)
        {
            IMicrophone microphone = new Microphone(make, model, price, hasCable);
            return microphone;
        }

        public IDrums CreateDrums(string make, string model, decimal price, string color, int width, int height)
        {
            IDrums drums = new Drums(make, model, price, color, false, width, height);
            return drums;
        }

        public IElectricGuitar CreateElectricGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets)
        {
            IElectricGuitar electricGuitar = new ElectricGuitar(make, model, price, color, true, bodyWood, fingerboardWood, 6, numberOfAdapters, numberOfFrets);
            return electricGuitar;
        }

        public IAcousticGuitar CreateAcousticGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
        {
            IAcousticGuitar acousticGuitar = new AcousticGitar(make, model, price, color, false, bodyWood, fingerboardWood, 6, caseIncluded, stringMaterial);
            return acousticGuitar;
        }

        public IBassGuitar CreateBassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood)
        {
            IBassGuitar bassGuitar = new BassGuitar(make, model, price, color, true, bodyWood, fingerboardWood, 4);
            return bassGuitar;
        }
    }
}
