namespace Simulator.Maps;

public class SmallTorusMap(int sizeX, int sizeY) : SmallMap(sizeX, sizeY)
{
    public override Point Next(Point p, Directions.Direction d)
    {
        p = p.Next(d);
        return OutOfBounds(p);
    }

    public override Point NextDiagonal(Point p, Directions.Direction d)
    {
        p = p.NextDiagonal(d);
        return OutOfBounds(p);
    }
    public Point OutOfBounds(Point p)
    {
        if (p.X < 0)
        {
            p = new Point(SizeX - 1, p.Y);
        }
        if (p.X >= SizeX)
        {
            p = new Point(0, p.Y);
        }
        if (p.Y < 0)
        {
            p = new Point(p.X, SizeY - 1);
        }
        if (p.Y >= SizeY)
        {
            p = new Point(p.X, 0);
        }
        return p;
    }
}
