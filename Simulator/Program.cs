using Simulator;
using System.Diagnostics;
using static Simulator.Directions;

class Program
{
    static void Main()
    {
        Lab5a();
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
}
