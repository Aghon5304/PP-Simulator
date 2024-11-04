namespace Simulator;

public abstract class Creature
{
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }

        init
        {
            value = value.Trim();
            if (value.Length > 25)
                value = value[0..25];
            value = value.Trim();
            if (value.Length < 3)
                value = value.PadRight(3, '#');
            _name = char.ToUpper(value[0]) + value[1..];
        }
    }
    public abstract int Power { get; }
    public int Level { get; set; }

    public Creature(string name = "Unknown", int level = 1)
    {
        name = name.Trim();
        if (name.Length > 25)
            name = name[0..25];
        name = name.Trim();
        if (name.Length < 3)
            name= name.PadRight(3, '#');
        _name = char.ToUpper(name[0]) + name[1..];
        if (level < 1)
            level = 1;
        if (level > 10)
            Level = 10;
        Level = level;
    }

    public abstract void SayHi();

    public string Info => $"{Name} ({Level})";

    public void Upgrade()
    {
        if (Level < 10)
            Level++;
    }
    public void Go(Directions.Direction Direction)
    {
        Console.WriteLine($"{Name} goes {Direction}.");
    }
    public void Go(Directions.Direction[] directions)
    {
        foreach(Directions.Direction x in directions)
        {
            Go(x);
        }
    }
    public void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }
}
