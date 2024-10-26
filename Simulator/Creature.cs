using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

internal class Creature
{
    public string Name { get; set; }
    public int Level { get; set; } = 1;

    public Creature(string name , int level)
    {
        Name = name;
        Level = level;
    }
    public void SayHi()
    {
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }
    }

    public void Info()
    {
        Console.WriteLine($"Name: {Name}, Level: {Level}");
    }
}
