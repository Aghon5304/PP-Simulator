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
    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }
}
