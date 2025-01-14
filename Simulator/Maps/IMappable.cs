using System.Linq.Expressions;

namespace Simulator.Maps;

public interface IMappable
{
    Map? Map { get; }
    Point Position { get; }
    string ToString();
    void Go(Directions.Direction Direction);
    void InitMapAndPosition(Map map, Point position);
    int Health { get; }
    int Power { get; }
    char Symbol { get; init; }
    int Experience { get; }
    int Level { get; }
    bool IsDead { get; }
    public void Heal(int amount);
    public void Damage(IMappable damageDealer);
    public void Upgrade();
    public void LevelUp(int experience);
}
