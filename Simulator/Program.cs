using Simulator;
using Simulator.Maps;
using System.Diagnostics;
using static Simulator.Directions;

class Program
{
    static void Main()
    {
        Lab5a();
        Lab5b();
    }

    static void Lab5a()
    {
        try
        {

            var r = new Rectangle(1, 2, 3, 4);
            Console.WriteLine(r.ToString());
            r = new Rectangle(5, 3, 4, 2);
            Console.WriteLine(r.ToString());
            r = new Rectangle(4, 4, 3, 2);
            Point a = new(3, 5);
            Point b = new(2, 1);
            Console.WriteLine(r.ToString());
            r = new Rectangle(a,b);
            Console.WriteLine(r.ToString());
            r = new Rectangle(1, 1, 1, 4);
            Console.WriteLine(r.ToString());
        }
        catch ( Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
    static void Lab5b()
    {
        var map = new SmallSquareMap(10);
        Point p = new(1, 1);
        Console.WriteLine($"Punkt :{p.ToString()}");
        Console.WriteLine(map.Next(p, Direction.Up).ToString());
        Console.WriteLine(map.Next(p, Direction.Right).ToString());
        Console.WriteLine(map.Next(p, Direction.Down).ToString());
        Console.WriteLine(map.Next(p, Direction.Left).ToString());
        Console.WriteLine(map.NextDiagonal(p, Direction.Up).ToString());
        Console.WriteLine(map.NextDiagonal(p, Direction.Right).ToString());
        Console.WriteLine(map.NextDiagonal(p, Direction.Down).ToString());
        Console.WriteLine(map.NextDiagonal(p, Direction.Left).ToString());
    }
}
