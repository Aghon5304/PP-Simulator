using Simulator.Maps;
using System.Runtime.Serialization.Formatters;
using Simulator;
namespace SimConsole;


public class SimulationHistory
{
    public Dictionary<int, HistoryValues> _symulacje = new();
    public Simulation Symulacja { get; private set; }

    public SimulationHistory(Simulation simulation)
    {
        Symulacja = simulation;
        MapVisualizer mapVisualizer = new(simulation.Map);
        while (!Symulacja.Finished)
        {
            HistoryValues values;
            if (Symulacja.CurrentMoveNumber() == 1)
            {
                values = new(null, null, mapVisualizer.Draw());
            }
            else
            {
                values = new(Symulacja.CurrentCreature(), Symulacja.CurrentMove(), mapVisualizer.Draw());
            }
            Symulacja.Turn();
            values.MapVisualization = mapVisualizer.Draw();
            _symulacje.Add(Symulacja.CurrentMoveNumber(), values);
        }
    }

    public void HistoriaSymulacji(int tura)
    {
        if (_symulacje.ContainsKey(tura))
        {
            var values = _symulacje[tura];
            Console.WriteLine($"Tura: {tura}\n{values.MapVisualization}\nW tej turze ruszył się: {values.current_creature}\nW kierunku: {values.current_direction}");
        }
        else
        {
            Console.WriteLine($"Tura {tura} nie istnieje w historii.");
        }
    }
}
