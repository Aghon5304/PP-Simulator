using System.Drawing;
using static Simulator.Directions;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public Dictionary<Point, List<IMappable>> _fields;
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
        _fields = new Dictionary<Point, List<IMappable>>();
    }
    public int SizeX { get; }
    public int SizeY { get; }

    public List<IMappable>? At(int x, int y)
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
    public void Add(IMappable creature, Point position)
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
    public void Remove(IMappable creature, Point position)
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
    public virtual void Move(IMappable creature, Point point)
    {
        Remove(creature, creature.Position);
        Add(creature, point);
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => !(p.X < 0 || p.Y < 0 || p.X >= SizeX || p.Y >= SizeY);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
