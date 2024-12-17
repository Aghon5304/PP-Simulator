using Simulator;
using Simulator.Maps;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new List<SimulationTurnLog>();
    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation;
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        for (int i = 0; i < _simulation.Moves.Length; i++)
        {
            if (TurnLogs.Count == 0)
            {
                TurnLogs.Add(new SimulationTurnLog
                {
                    Mappable = "Starting positions",
                    Move = "None",
                    Symbols = new Dictionary<Point, char>(_simulation.Symbols)
                });
            }
            else
            {
                TurnLogs.Add(new SimulationTurnLog
                {
                    Mappable = _simulation.CurrentCreature().ToString(),
                    Move = _simulation.CurrentMove().ToString(),
                    Symbols = new Dictionary<Point, char>(_simulation.CurrentSymbols())
                });
            }
            _simulation.Turn();
        }
    }
}
