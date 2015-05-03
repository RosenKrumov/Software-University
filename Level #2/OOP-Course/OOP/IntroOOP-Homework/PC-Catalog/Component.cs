using System;
class Component
{
    private string name;
    private string details;
    private decimal price;

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
                throw new ArgumentNullException("Component name must not be empty");
            }

            this.name = value;
        }
    }

    public string Details
    {
        get
        {
            return this.details;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Component details must not be empty");
            }

            this.details = value;
        }
    }

    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Component price must not be negative");
            }

            this.price = value;
        }
    }

    public Component(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public Component(string name, string details, decimal price)
        : this(name, price)
    {
        this.Details = details;
    }

    public override string ToString()
    {
        string componentInfo = string.Format("Name: {0}\n", this.name);
        
        if (this.details != null)
        {
            componentInfo += string.Format("Details: {0}\n", this.details);
        }
        
        componentInfo += string.Format("Price: {0} BGN\n", this.price);
        
        return componentInfo;
    }
}