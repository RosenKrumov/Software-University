using System;

class Laptop
{
    private string model;
    private string manufacturer;
    private string processor;
    private string ram;
    private string graphicsCard;
    private string hdd;
    private string screen;
    private Battery battery;
    private decimal price;

    public string Model
    {
        get
        {
            return this.model;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Laptop model cannot be empty.");
            }

            this.model = value;
        }
    }

    public string Manufacturer
    {
        get
        {
            return this.manufacturer;
        }

        set
        {
            if (value != null && value.Length < 1)
            {
                throw new Exception("Wrong value for laptop manufacturer");
            }
            this.manufacturer = value;
        }
    }

    public string Processor
    {
        get
        {
            return this.processor;
        }

        set
        {
            if (value != null && value.Length < 1)
            {
                throw new Exception("Wrong value for laptop processor");
            }
            this.processor = value;
        }
    }

    public string Ram
    {
        get
        {
            return this.ram;
        }

        set
        {
            if (value != null && value.Length < 1)
            {
                throw new Exception("Wrong value for laptop RAM");
            }
        }
    }

    public string GraphicsCard
    {
        get
        {
            return this.graphicsCard;
        }

        set
        {
            if (value != null && value.Length < 1)
            {
                throw new Exception("Wrong value for laptop graphics");
            }
            this.graphicsCard = value;
        }
    }

    public string Hdd
    {
        get
        {
            return this.hdd;
        }

        set
        {
            if (value != null && value.Length < 1)
            {
                throw new Exception("Wrong value for laptop HDD");
            }
            this.hdd = value;
        }
    }

    public string Screen
    {
        get
        {
            return this.screen;
        }

        set
        {
            if (value != null && value.Length < 1)
            {
                throw new Exception("Wrong value for laptop screen");
            }
            this.screen = value;
        }
    }

    public Battery Battery
    {
        get
        {
            return this.battery;
        }

        set
        {
            this.battery = value;
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
                throw new Exception("Laptop price cannot be negative.");
            }

            this.price = value;
        }
    }

    public Laptop(string model, decimal price)
    {
        this.Model = model;
        this.Price = price;
    }

    public Laptop(string model, decimal price, string manufacturer = null, string processor = null, string ram = null, string graphicsCard = null, string hdd = null, string screen = null, Battery battery = null) : this(model, price)
    {
        this.Manufacturer = manufacturer;
        this.Processor = processor;
        this.Ram = ram;
        this.GraphicsCard = graphicsCard;
        this.Hdd = hdd;
        this.Screen = screen;
        this.Battery = battery;
    }

    public override string ToString()
    {
        string result = string.Format("Model: {0}", this.model, this.price);

        if (this.Manufacturer != null)
        {
            result += " Manufacturer: " + this.manufacturer;
        }

        if (this.Processor != null)
        {
            result += " Processor: " + this.processor;
        }

        if (this.Ram != null)
        {
            result += " RAM: " + this.ram;
        }

        if (this.GraphicsCard != null)
        {
            result += " Graphics: " + this.graphicsCard;
        }

        if (this.Hdd != null)
        {
            result += " HDD: " + this.hdd;
        }

        if (this.Screen != null)
        {
            result += " Screen: " + this.screen;
        }

        if (this.Battery != null)
        {
            result += this.battery;
        }

        result += " Price: " + this.price + " lv.";

        return result;
    }
}