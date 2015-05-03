namespace Customer
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Customer : IComparable<Customer>, ICloneable
    {
        private string firstName;
        private string midName;
        private string lastName;
        private int id;
        private string permAddress;
        private string phone;
        private string email;
        private IList<Payment> payments;

        public Customer(string firstName, string midName, string lastName, int id, string permAddress, string phone,
            string email, IList<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MidName = midName;
            this.LastName = lastName;
            this.Id = id;
            this.PermAddress = permAddress;
            this.Phone = phone;
            this.Email = email;
            this.Payments = payments;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name must not be empty.");
                }
                this.firstName = value;
            }
        }

        public string MidName
        {
            get { return this.midName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Mid name must not be empty.");
                }
                this.midName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name must not be empty.");
                }
                this.lastName = value;
            }
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ID must be positive.");
                }
                this.id = value;
            }
        }

        public string PermAddress
        {
            get { return this.permAddress; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Permanent address must not be empty.");
                }
                this.permAddress = value;
            }
        }

        public string Phone
        {
            get { return this.phone; }
            set
            {
                if (!ValidatePhone(value))
                {
                    throw new ArgumentException("Invalid phone.");
                }
                this.phone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (!ValidateEmail(value))
                {
                    throw new ArgumentException("Invalid email.");
                }
                this.email = value;
            }
        }

        public IList<Payment> Payments { get; set; }

        public CustomerType CustomerType { get; set; }

        public static bool ValidatePhone(string str)
        {
            Regex r = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            if (r.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        public static bool ValidateEmail(string str)
        {
            Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (r.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        public void AddPayment(Payment payment)
        {
            this.Payments.Add(payment);
            var paymetsCount = this.Payments.Count;
            if (paymetsCount <= 1)
            {
                this.CustomerType = CustomerType.OneTime;
            }

            if (paymetsCount >= 2)
            {
                this.CustomerType = CustomerType.Regular;
            }

            if (paymetsCount >= 5)
            {
                this.CustomerType = CustomerType.Golden;
            }

            if (paymetsCount >= 8)
            {
                this.CustomerType = CustomerType.Diamond;
            }
        }

        protected bool Equals(Customer other)
        {
            return string.Equals(FirstName, other.FirstName) && string.Equals(MidleName, other.MidleName) && string.Equals(LastName, other.LastName) && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Customer)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return this.Id.GetHashCode();
            }
        }

        public static bool operator ==(Customer firstCustomer, Customer secondCustomer)
        {
            return firstCustomer.Equals(secondCustomer);
        }

        public static bool operator !=(Customer firstCustomer, Customer secondCustomer)
        {
            return firstCustomer.Equals(secondCustomer);
        }

        public object Clone()
        {
            var cloning = new Customer(this.FirstName, this.MidName, this.LastName,
            this.Id, this.PermAddress, this.Phone, this.Email, this.Payments, this.CustomerType);

            cloning.Payments = new List<Payment>();
            foreach (var payment in this.Payments)
            {
                cloning.Payments.Add(new Payment(payment.ProductName, payment.Price));
            }
            cloning.CustomerType = this.CustomerType;

            return cloning;
        }

        public int CompareTo(Customer other)
        {
            string fullNameThisCustomer = this.ToString();
            string fullNameOtherCustomer = other.ToString();
            if (fullNameThisCustomer.CompareTo(fullNameOtherCustomer) == 0)
            {
                return this.Id.CompareTo(other.Id);
            }

            return fullNameThisCustomer.CompareTo(fullNameOtherCustomer);
        }

        public override string ToString()
        {
            string output = string.Format("First name: {0}\n" +
                                          "Mid name: {1}\n" +
                                          "Last name: {2}\n" +
                                          "ID: {3}\n" +
                                          "Address: {4}\n" +
                                          "Phone: {5}\n" +
                                          "Email: {6}\n" +
                                          "Payments: {7}\n",
                this.FirstName, this.MidName, this.LastName,
                this.Id, this.PermAddress, this.Phone, this.Email,
                this.Payments);
            return output;
        }
    }
}
