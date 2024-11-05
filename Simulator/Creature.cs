using System.Reflection.Emit;
using System.Xml.Linq;

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
            _name = Walidatory.Shortener(value, 3, 25, '#');
        }
    }
    public abstract int Power { get; }
    public int Level { get; set; }

    public Creature(string name = "Unknown", int level = 1)
    {
        _name = Walidatory.Shortener(name, 3, 25, '#');
        Level = Walidatory.Limiter(level, 1, 10);
    }

    public abstract void SayHi();

    public abstract string Info { get; }
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
    public override string? ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}