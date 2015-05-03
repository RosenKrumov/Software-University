namespace GalacticGPS
{
    using System;
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.planet = planet;
        }

        public override string ToString()
        {
            string output = string.Format("{0}, {1} - {2}", this.latitude, this.longitude, this.planet);
            return output;
        }
    }
}
