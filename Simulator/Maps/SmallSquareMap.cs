
namespace Simulator.Maps;

public class SmallSquareMap(int size) : SmallMap(size, size)
{
    public override Point Next(Point p, Directions.Direction d)
    {
        if (Exist(p.Next(d)))
        {
            return p.Next(d);
        }
        else
        {
            return p;
        }
    }

    public override Point NextDiagonal(Point p, Directions.Direction d)
    {
        if (Exist(p.NextDiagonal(d)))
        {
            return p.NextDiagonal(d);
        }
        else
        {
            return p;
        }
    }

    public override void Remove(Creature creature, Point position)
    {
        throw new NotImplementedException();
    }
}
