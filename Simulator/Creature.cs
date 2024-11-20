using static Simulator.Directions;
using Simulator.Maps;

namespace Simulator;

public abstract class Creature(string name = "Unknown", int level = 1)
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public void InitMapAndPosition(Map map, Point position)
    {
        if (Map ==null)
        {

        }
    }

    //znajduje się na mapie w danym miejscu
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
    public static string Go(Directions.Direction Direction)
    {
        //zgodnie z regułami mapy

        return $"{Direction.ToString().ToLower()}.";
    }

    //out
    public static string[] Go(Directions.Direction[] directions)
    {
        var result = new string[directions.Length];
        for(int x=0;x< directions.Length;x++)
        {
            result[x] = Go(directions[x]);
        }
        return result;
    }
    // out 
    public static void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }
    public override string? ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}