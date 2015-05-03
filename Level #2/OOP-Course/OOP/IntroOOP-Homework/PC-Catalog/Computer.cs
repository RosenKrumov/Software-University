using System;
class Computer
{
    private string name;
    private Component ram;
    private Component processor;
    private Component graphics;

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
                throw new ArgumentNullException("PC name must not be empty");
            }
            this.name = value;
        }
    }

    public Component Ram
    {
        get
        {
            return this.ram;
        }
        set
        {
            this.ram = value;
        }
    }

    public Component Processor
    {
        get
        {
            return this.processor;
        }
        set
        {
            this.processor = value;
        }
    }

    public Component Graphics
    {
        get
        {
            return this.graphics;
        }
        set
        {
            this.graphics = value;
        }
    }

    public decimal TotalPrice
    {
        get
        {
            return this.ram.Price + this.processor.Price + this.graphics.Price;
        }
    }

    public Computer(string name, Component ram, Component processor, Component graphics)
    {
        this.Name = name;
        this.Ram = ram;
        this.Processor = processor;
        this.Graphics = graphics;
    }

    public override string ToString()
    {
        string information = string.Format("Name: {0}\n", this.name);

        information += "Components info:\n";
        
        if (this.processor != null)
        {
            information += this.processor;
        }
        if (this.graphics != null)
        {
            information += this.graphics;
        }
        if (this.ram != null)
        {
            information += this.ram;
        }

        information += string.Format("Total price: {0} BGN\n", this.TotalPrice);
        
        return information;
    }
}