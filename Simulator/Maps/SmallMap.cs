using System.Drawing;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{

    public List<IMappable>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
        _fields = new List<IMappable>?[sizeX, sizeY];
    }
    public override List<IMappable>? At(int x, int y)
    {
        return _fields[x, y];
    }
    public List<IMappable>? At(Point point)
    {
       return At(point.X, point.Y);
    }
    public override void Add(IMappable creature, Point position)
    {

        if (creature == null)
        {
            throw new ArgumentNullException("Nie można dodać creature ponieważ ma wartość Null");
        }
        else if( position.X < 0 || position.Y < 0 || position.X >= SizeX || position.Y >= SizeY)
        {
            throw new ArgumentOutOfRangeException("Position is out of bounds");
        }
        else
        {
            if (_fields[position.X, position.Y] is null)
            {
                _fields[position.X, position.Y] = new List<IMappable>();
            }    
            _fields[position.X, position.Y].Add(creature);
        }
    }
    public override void Remove(IMappable creature, Point position)
    {
        if (creature == null)
        {
            throw new ArgumentNullException("Nie można dodać creature ponieważ ma wartość Null");
        }
        else if (position.X < 0 || position.Y < 0 || position.X >= SizeX || position.Y >= SizeY)
        {
            throw new ArgumentOutOfRangeException("Position is out of bounds");
        }
        else if (_fields[position.X, position.Y] == null)
        {
            throw new ArgumentNullException("Position is empty ");
        }
        else if (!_fields[position.X, position.Y].Contains(creature))
        {
            throw new ArgumentException("No desired creature at position");
        }
        else
        {
            if (_fields[position.X, position.Y].Count == 1)
            {
                _fields[position.X, position.Y] = null;
            }
            else
            {
                _fields[position.X, position.Y].Remove(creature);
            }
        }
    }
}
