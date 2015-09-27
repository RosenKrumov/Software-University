namespace ConnectedAreasInMatrix
{
    using System;

    public class ConnectedArea : IComparable<ConnectedArea>
    {
        public Point Start { get; set; }
        public int Size { get; set; }

        public int CompareTo(ConnectedArea other)
        {
            var result = other.Size.CompareTo(this.Size);

            if (result == 0)
            {
                result = this.Start.X.CompareTo(other.Start.X);
                if (result == 0)
                {
                    result = this.Start.Y.CompareTo(other.Start.Y);
                }
                
                return result;
            }
            
            return result;
        }
    }
}
