using System.Runtime.CompilerServices;

namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _rageCount;
    public override int Power => (7 * Level) + 3 * Rage;
    public int Rage
    {
        get => _rage;
        set => _rage = value < 0 ? 0 : value > 10 ? 10 : value;
    }
    public void Hunt()
    {
        _rageCount++;
        if (_rageCount % 2 == 0)
        {
            Rage++;
        }
        Console.WriteLine($"{Name} is hunting.");
    }

    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public Orc() : base() { }
    public override string Info
    {
        get {return $"{Name} [{Level}][{Rage}]"; }
    }
}
