using Direction = Simulator.Directions.Direction;
namespace Simulator.Maps;

public class BigBounceMap(int sizeX, int sizeY) : BigMap(sizeX, sizeY)
{
    public Direction Bounce(Direction d)
    {
        if (d == Direction.Up) return Direction.Down;
        if (d == Direction.Down) return Direction.Up;
        if (d == Direction.Left) return Direction.Right;
        if (d == Direction.Right) return Direction.Left;
        return d;
    }
    public override Point Next(Point p, Direction d)
    {
        if (Exist(p.Next(d)))
        {
            return p.Next(d);
        }
        else
        {
            return p.Next(Bounce(d));
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p.NextDiagonal(d)))
        {
            return p.NextDiagonal(d);
        }
        else
        {
            return p.NextDiagonal(Bounce(d));
        }
    }
}
