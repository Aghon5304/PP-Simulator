namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount = 0;
    public override int Power => (8 * Level) + 2 * Agility;
    public int Agility
    {
        get => _agility;
        private set => _agility = value < 0 ? 0 : value > 10 ? 10 : value;
    }
    public void Sing()
    {
        _singCount++;
        if (_singCount % 3 == 0)
        {
            Agility++;
        }
        Console.WriteLine($"{Name} is singing.");
    }
    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public Elf() : base() { }
}
