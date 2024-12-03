using System.Linq.Expressions;

namespace Simulator.Maps;

public interface IMappable
{
    Map? Map { get; }
    Point Position { get; }

    void Go(Directions.Direction Direction);
    void InitMapAndPosition(Map map, Point position);
    
    char Symbol { get; init; }
}
