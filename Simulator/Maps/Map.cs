using System.Drawing;
using static Simulator.Directions;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
        SizeX = sizeX;
        SizeY = sizeY;
    }
    public int SizeX { get; }
    public int SizeY { get; }

    public abstract void Add(IMappable creature, Point position);
    public abstract void Remove(IMappable creature, Point position);
    public virtual void Move(IMappable creature, Point point)
    {
        Remove(creature, creature.Position);
        Add(creature, point);
    }
    public abstract List<IMappable>? At(int x, int y);

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
