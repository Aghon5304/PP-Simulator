namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }
    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Size of SmallTorusMap must be between 5 and 20");
        }
        Size = size;
    }
    public override bool Exist(Point p)
    {
        return !(p.X < 0 || p.Y < 0 || p.X >= Size || p.Y >= Size);
    }

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
            p = new Point(Size - 1, p.Y);
        }
        if (p.X >= Size)
        {
            p = new Point(0, p.Y);
        }
        if (p.Y < 0)
        {
            p = new Point(p.X, Size - 1);
        }
        if (p.Y >= Size)
        {
            p = new Point(p.X, 0);
        }
        return p;
    }
}
