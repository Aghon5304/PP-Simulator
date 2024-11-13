using System.Reflection.Emit;
using System.Xml.Linq;
using static Simulator.Directions;

namespace Simulator;

public abstract class Creature(string name = "Unknown", int level = 1)
{
    private string _name = Walidatory.Shortener(name, 3, 25, '#');
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
    public int Level { get; set; } = Walidatory.Limiter(level, 1, 10);

    public abstract string Greeting();

    public abstract string Info { get; }
    public void Upgrade()
    {
        if (Level < 10)
            Level++;
    }
    public static string Go(Directions.Direction Direction) => $"{Direction.ToString().ToLower()}.";
    public static string[] Go(Directions.Direction[] directions)
    {
        var result = new string[directions.Length];
        for(int x=0;x< directions.Length;x++)
        {
            result[x] = Go(directions[x]);
        }
        return result;
    }
    public static void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }
    public override string? ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}