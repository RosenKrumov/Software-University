using System.Text;

namespace Estates.Data
{
    using Interfaces;

    public class Offer : IOffer
    {
        public Offer(OfferType type, IEstate estate)
            : this(type)
        {
            this.Estate = estate;
        }

        public Offer(OfferType type)
        {
            this.Type = type;
        }

        public OfferType Type { get; set; }

        public IEstate Estate { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat(
                "{0}: Estate = {1}, " +
                "Location = {2}, ",
                this.Type,
                this.Estate.Name,
                this.Estate.Location);
            return sb.ToString();
        }
    }
}
