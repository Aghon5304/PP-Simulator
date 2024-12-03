using Simulator.Maps;
using Simulator;
using System.Runtime.InteropServices;

namespace SimConsole;
public class Program
{
    public static void Main()
    {
        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        for (int i = 0; i < moves.Length; i++)
        {
            mapVisualizer.Draw();
            Console.WriteLine("\nPress any button to continue");
            Console.ReadKey();
            Console.Clear();
            simulation.Turn();
        }
        

    }
}