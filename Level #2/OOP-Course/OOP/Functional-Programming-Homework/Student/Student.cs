using System.Text.RegularExpressions;

namespace Student
{
    using System;
    using System.Collections.Generic;

    class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private int facultyNumber;
        private string phone;
        private string email;
        private IList<int> marks;
        private int groupNumber;

        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email,
            IList<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name must not be empty");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name must not be empty.");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age must be positive.");
                }
                this.age = value;
            }
        }

        public int FacultyNumber
        {
            get { return this.facultyNumber; }
            private set
            {
                if (value < 0 || Convert.ToString(value).Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Faculty number must be positive and between 10000 and 99999");
                }
                this.facultyNumber = value;
            }
        }

        public string Phone
        {
            get { return this.phone; }
            private set
            {
                if (!ValidatePhone(value))
                {
                    throw new ArgumentException("Invalid phone number.");
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
                    throw new ArgumentException("Invalid email");
                }
                this.email = value;
            }
        }

        public IList<int> Marks
        {
            get { return this.marks; }
            set
            {
                if (!CheckMarks(value))
                {
                    throw new ArgumentOutOfRangeException("Marks must be between 2 and 6");
                }
                this.marks = value;
            }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Group number must be positive.");
                }
                this.groupNumber = value;
            }
        }

        public static bool CheckMarks(IList<int> marks)
        {
            foreach (var mark in marks)
            {
                if (mark < 2 || mark > 6)
                {
                    return false;
                }
            }
            return true;
        }

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

        public override string ToString()
        {
            string marks = string.Join(",", this.Marks);
            string output =
                string.Format("First name: {0}\n" +
                              "Last name: {1}\n" +
                              "Age: {2}\n" +
                              "Faculty number: {3}\n" +
                              "Phone number: {4}\n" +
                              "Email: {5}\n" +
                              "Marks: {6}\n" +
                              "Group number: {7}",
                              this.FirstName, this.LastName,
                    this.Age, this.FacultyNumber, this.Phone,
                    this.Email, marks, this.GroupNumber);
            output += "\n";
            return output;
        }
    }
}