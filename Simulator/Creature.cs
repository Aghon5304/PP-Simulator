﻿using static Simulator.Directions;
using Simulator.Maps;

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

    public abstract string Info { get; }
    public virtual char Symbol { get; init; } = 'C';
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public void Upgrade()
    {
        if (Level < 10)
            Level++;
    }
    public void Go(Directions.Direction Direction)
    {
        if (Map != null)
        {
            Map.Move(this, Map.Next(Position, Direction));
            Position = Map.Next(Position, Direction);
        }
    }
}