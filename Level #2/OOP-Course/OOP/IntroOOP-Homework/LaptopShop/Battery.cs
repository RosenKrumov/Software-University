using System;

class Battery
{
    private string name;
    private double life;

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (!CheckName(value))
            {
                throw new Exception("Name cannot be null.");
            }
            this.name = value;
        }
    }

    public double Life
    {
        get
        {
            return this.life;
        }

        set
        {
            if (!CheckLife(value))
            {
                throw new Exception("Battery life cannot be negative.");
            }
            this.life = value;
        }
    }

    public Battery(string name)
    {
        this.Name = name;
    }

    public Battery(string name, double life)
        : this(name)
    {
        this.Life = life;
    }

    private bool CheckName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }
        return true;
    }

    private bool CheckLife(double life)
    {
        if (life < 0)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        string batteryInfo = string.Format("Name: {0}", this.name);
        
        if (this.Life != null)
        {
            batteryInfo += string.Format(" Life: {0} hours", this.life);
        }

        return batteryInfo;
    }
}