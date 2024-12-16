﻿using Simulator;
using Simulator.Maps;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        if (TurnLogs.Count == 0)
        {
            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = "Starting positions",
                Move = "None",
                Symbols = _simulation.Symbols
            });
        }
    }
}