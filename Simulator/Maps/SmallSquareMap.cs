namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }
    public SmallSquareMap(int size)
    {
        if( size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Size of SmallSquareMap must be between 5 and 20");
        }
        Size = size;
    }
    public override bool Exist(Point p)
    {
        return p.X < 0 || p.Y < 0 || p.X >= Size || p.Y >= Size;
    }

    public override Point Next(Point p, Directions.Direction d)
    {
        if (!Exist(p.Next(d)))
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
        if (!Exist(p.NextDiagonal(d)))
        {
            return p.NextDiagonal(d);
        }
        else
        {
            return p;
        }
    }
}
