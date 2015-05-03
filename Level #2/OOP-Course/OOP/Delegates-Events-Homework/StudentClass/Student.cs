namespace StudentClass
{
    using System;

    public delegate void ChangedPropertyEventHandler(object sender, PropertyChangedEventArgs e);

    public class Student
    {
        private string name;
        private int age;
        public event ChangedPropertyEventHandler PropertyChanged;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.PropertyChanged += this.GetMessage;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty.");
                }
             
                var ev = new PropertyChangedEventArgs { OldName = this.name, Name = value, ChangedProperty = "Name" };
                this.name = value;
                this.OnChanged(this, ev);
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age must be positive.");
                }

                var ev = new PropertyChangedEventArgs { OldAge = this.age, Age = value, ChangedProperty = "Age" };
                this.age = value;
                this.OnChanged(this, ev);
            }
        }

        protected virtual void OnChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }

        private void GetMessage(object sender, PropertyChangedEventArgs e)
        {
            switch (e.ChangedProperty)
            {
                case "Name":
                    Console.WriteLine("Property changed: Name (from {0} to {1}).", e.OldName, e.Name);
                    break;
                case "Age":
                    Console.WriteLine("Property changed: Age (from {0} to {1}).", e.OldAge, e.Age);
                    break;
            }
        }
    }
}
