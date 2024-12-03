using System.ComponentModel;
using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string _description;
    public string Description
    {
        get => _description;
        private set => _description = Walidatory.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; set; } = 3;
    public Animals(string description = "Unknown", uint size = 3)
    {
        Description = description;
        Size = size > 1 ? size : 1;
    }



    public Map? Map { get; private set; }

    public Point Position { get; private set; }

    public virtual char Symbol { get; init; } = 'A';

    

    public virtual string Info => $"{Description} <{Size}>";

    public override string? ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public void Go(Directions.Direction Direction)
    {
        if (Map != null)
        {
            Map.Move(this, Map.Next(Position, Direction));
            Position = Map.Next(Position, Direction);
        }
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null)
        {
            throw new ArgumentNullException("Map is null");
        }
        else
        {
            Map = map;
            Map.Add(this, position);
            Position = position;
        }
    }
}
