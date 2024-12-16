using Simulator.Maps;
using Simulator;
using System.Runtime.InteropServices;

namespace SimConsole;
public class Program
{
    public static void Main()
    {
        SmallTorusMap map = new SmallTorusMap(8,6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals("Królików"), new Birds("Strusie",canFly:true), new Birds("Orły", canFly:false)];
        List<Point> points = [new(2, 2), new(3, 1),new(4,5),new(1,3),new(2,1)];
        string moves = "uuuuudddddlllllrrrrr";
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        for (int i = 0; i < moves.Length; i++)
        {
            Console.Write(mapVisualizer.Draw());
            Console.WriteLine("\nPress any button to continue");
            Console.ReadKey();
            Console.Clear();
            simulation.Turn();
        }


    }
}