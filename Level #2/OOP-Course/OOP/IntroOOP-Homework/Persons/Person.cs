using System;

class Person
{
    private string name;
    private int age;
    private string email;

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Name cannot be null or empty");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }

        set
        {
            if (!CheckAge(value))
            {
                throw new Exception("Age must be between 1 and 100.");
            }
            this.age = value;
        }
    }

    public string Email
    {
        get
        {
            return this.email;
        }

        set
        {
            if (!CheckEmail(value))
            {
                throw new Exception("Email should contain @.");
            }

            this.email = value;
        }
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Person(string name, int age, string email) : this(name, age)
    {
        this.Email = email;
    }

    private bool CheckAge(int age)
    {
        if (age < 1 || age > 100)
        {
            return false;
        }

        return true;
    }

    private bool CheckEmail(string email)
    {
        if (email != null && !email.Contains("@"))
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        string result = String.Format("Name: {0} Age: {1}", this.name, this.age);
        if (this.Email != null)
        {
            result += " Email: " + this.email;
        }

        return result;
    }
}