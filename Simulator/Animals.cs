using System.ComponentModel;
using System.Drawing;
using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string _description;
    public string Description
    {
        get => _description;
        private set => _description = Walidatory.Shortener(value, 3, 15, '#');
    }
    public int Size { get; set; } = 3;
    public Animals(string description = "Unknown", int size = 3)
    {
        Description = description;
        Size = size > 1 ? size : 1;
    }
    public bool IsDead { get; private set; } = false;
    public virtual Map? Map { get; protected set; }

    public virtual Point Position { get; protected set; }
    public virtual char Symbol { get; init; } = 'A';
    public virtual string Info => $"{Description} <{Size}>";

    public virtual int MaxHealth { get; private set; }
    public virtual int Health { get; private set; }

    public virtual int Power { get; } = 1;

    public int Experience { get; set; }

    public int Level { get; private set; }

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
            damageDealer.Heal(Size*5);
            damageDealer.LevelUp(Experience);
        }
    }
    public void LevelUp(int experience)
    {
        Experience += experience;
        if (Experience >= Size * 5)
        {
            for(int a = experience/5-Size;a > 0; a--)
            {
                Upgrade();
            }
        }
    }
    public void Upgrade()
    {
        if (Size < 10)
        {
            Size++;
        }
        Level = Size;
        MaxHealth = 20 * Size;
        Health = MaxHealth;
    }
    public override string? ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public virtual void Go(Directions.Direction Direction)
    {
        if (Map != null)
        {
            Map.Move(this, Map.Next(Position, Direction));
            Position = Map.Next(Position, Direction);
        }
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null)
        {
            throw new ArgumentNullException("Map is null");
        }
        else
        {
            Map = map;
            Map.Add(this, position);
            Position = position;
        }
    }
}
