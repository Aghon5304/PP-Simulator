
using System.Collections.Generic;

namespace Simulator.Maps;

public abstract class BigMap : Map
{
    public Dictionary<Point, List<IMappable>> _fields;
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
        _fields = new Dictionary<Point, List<IMappable>>();
    }
    public override List<IMappable>? At(int x, int y)
    {
        var point = new Point(x, y);
        if (_fields.ContainsKey(point))
        {
            return _fields[point];
        }
        else
        {
            return null;
        }
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
        else if (position.X < 0 || position.Y < 0 || position.X >= SizeX || position.Y >= SizeY)
        {
            throw new ArgumentOutOfRangeException("Position is out of bounds");
        }
        else
        {
            if (!_fields.ContainsKey(position))
            {
                _fields[position] = new List<IMappable>();
            }
            _fields[position].Add(creature);
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
        else if (!_fields.ContainsKey(position))
        {
            throw new ArgumentNullException("Position is empty ");
        }
        else if (!_fields[position].Contains(creature))
        {
            throw new ArgumentException("No desired creature at position");
        }
        else
        {
            _fields[position].Remove(creature);
            if (_fields[position].Count == 0)
            {
                _fields.Remove(position);
            }
        }
    }
}
