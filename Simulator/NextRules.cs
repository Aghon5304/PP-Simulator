using Simulator.Maps;
using static Simulator.Directions;
namespace Simulator;

internal static class NextRules
{
	public static Point WallNext(Map map ,Point p, Directions.Direction d)
	{
		if (map.Exist(p.Next(d)))
		{
			return p.Next(d);
		}
		else
		{
			return p;
		}
	}
	public static Point WallNextDiagonal(Map map, Point p, Directions.Direction d)
	{
		if (map.Exist(p.NextDiagonal(d)))
		{
			return p.NextDiagonal(d);
		}
		else
		{
			return p;
		}
	}
	public static Point TorusNext(Map map, Point p, Directions.Direction d)
	{
		p = p.Next(d);
		return OutOfBounds(map, p);
	}
	public static Point TorusNextDiagonal(Map map, Point p, Directions.Direction d)
	{
		p = p.NextDiagonal(d);
		return OutOfBounds(map, p);
	}
	public static Point OutOfBounds(Map map,Point p)
	{
		if (p.X < 0)
		{
			p = new Point(map.SizeX - 1, p.Y);
		}
		if (p.X >= map.SizeX)
		{
			p = new Point(0, p.Y);
		}
		if (p.Y < 0)
		{
			p = new Point(p.X,map.SizeY - 1);
		}
		if (p.Y >= map.SizeY)
		{
			p = new Point(p.X, 0);
		}
		return p;
	}
	public static Direction Bounce(Direction d)
	{
		if (d == Direction.Up) return Direction.Down;
		if (d == Direction.Down) return Direction.Up;
		if (d == Direction.Left) return Direction.Right;
		if (d == Direction.Right) return Direction.Left;
		return d;
	}
	public static Point BounceNext(Map map,Point p, Direction d)
	{
		if (map.Exist(p.Next(d)))
		{
			return p.Next(d);
		}
		else
		{
			return p.Next(Bounce(d));
		}
	}

	public static Point BounceNextDiagonal(Map map, Point p, Direction d)
	{
		if (map.Exist(p.NextDiagonal(d)))
		{
			return p.NextDiagonal(d);
		}
		else
		{
			return p.NextDiagonal(Bounce(d));
		}
	}
}
