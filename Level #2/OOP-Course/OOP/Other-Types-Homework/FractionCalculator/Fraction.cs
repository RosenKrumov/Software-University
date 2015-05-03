namespace FractionCalculator
{
    using System;
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public long Numerator
        {
            get
            {
                return this.numerator;
            }
            set
            {
                this.numerator = value;
            }
        }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be 0.");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction fr1, Fraction fr2)
        {
                fr1.Numerator *= fr2.Denominator;
                fr2.Numerator *= fr1.Denominator;
                long commonDenominator = fr1.Denominator * fr2.Denominator;

                return new Fraction(fr1.Numerator + fr2.Numerator, commonDenominator);
        }

        public static Fraction operator -(Fraction fr1, Fraction fr2)
        {
                fr1.Numerator *= fr2.Denominator;
                fr2.Numerator *= fr1.Denominator;
                long commonDenominator = fr1.Denominator * fr2.Denominator;

                return new Fraction(fr1.Numerator - fr2.Numerator, commonDenominator);
        }

        public override string ToString()
        {
            string output = string.Format("{0}", (decimal)this.Numerator / this.Denominator);
            return output;
        }
    }
}
