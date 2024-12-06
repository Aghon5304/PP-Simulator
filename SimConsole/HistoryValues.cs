using Simulator.Maps;
using Simulator;

namespace SimConsole;

public class HistoryValues(IMappable? creature, Directions.Direction? direction, string map)
{
    public IMappable? current_creature { get; set; } = creature;
    public Directions.Direction? current_direction { get; set; } = direction;
    public string MapVisualization { get; set; } = map;
}
