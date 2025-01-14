using static Simulator.Directions;
using Simulator.Maps;
using System.Drawing;

namespace Simulator;

public abstract class Creature(string name = "Unknown", int level = 1) : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map),"Map is null");
        }
        else
        {
            Map = map;
            Map.Add(this, position);
            Position = position;
        }
    }

    //znajduje się na mapie w danym miejscu
    private string _name = Walidatory.Shortener(name, 3, 25, '#');
    public string Name
    {
        get
        {
            return _name;
        }

        init
        {
            _name = Walidatory.Shortener(value, 3, 25, '#');
        }
    }
    public abstract int Power { get; }
    public int Level { get; set; } = Walidatory.Limiter(level, 1, 10);

    public abstract string Greeting();
    public bool IsDead { get; private set; } = false;
    public abstract string Info { get; }
    public virtual char Symbol { get; init; } = 'C';

    public virtual int MaxHealth { get; private set; }
    public virtual int Health { get; private set; }

    public int Experience { get; private set; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public void Upgrade()
    {
        if (Level < 10)
        {
            Level++;
        }
        MaxHealth = 20*Level;
        Health = MaxHealth;
    }
    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }
    public void Damage(IMappable damageDealer)
    {
        var amount = damageDealer.Power;
        Health -= amount;
        if (Health < 0)
        {
            Health = 0;
        }
        if (Health == 0)
        {
            IsDead = true;
            damageDealer.Upgrade();
        }
    }
    public void Go(Directions.Direction Direction)
    {
        if (Map != null)
        {
            Map.Move(this, Map.Next(Position, Direction));
            Position = Map.Next(Position, Direction);
        }
    }

    public void LevelUp(int experience)
    {
        Experience += experience;
        for (int a = Experience / 10 - Level; a > 0; a--)
        {
            Upgrade();
        }
    }
}