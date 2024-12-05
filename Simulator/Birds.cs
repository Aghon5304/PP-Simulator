using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Xml.Linq;
using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public Boolean CanFly { get; set; }
    public new void InitMapAndPosition(Map map, Point position)
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
    public override char Symbol { get; init; }
    public Birds(string Description = "Unknown", uint Size = 3, Boolean canFly = true) : base(Description,Size)
    {
        CanFly = canFly;
        if (CanFly == false)
        {
            Symbol = 'b';
        }
        else
        {
            Symbol = 'B';
        }
    }
    public Birds() : base() { }
    public override string Info
    {
        get { return $"{Description}(fly{(CanFly == true ? '+' : '-')}) <{Size}>"; }
    }
    public override void Go(Directions.Direction Direction)
    {
        if (CanFly == true)
        {
            if (Map != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    Map.Move(this, Map.Next(Position, Direction));
                    Position = Map.Next(Position, Direction);
                }
            }
        }
        else
        {
            if (Map != null)
            {
                Map.Move(this, Map.NextDiagonal(Position, Direction));
                Position = Map.NextDiagonal(Position, Direction);
            }
        }
    }
}
