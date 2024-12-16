using Simulator.Maps;
using System.Drawing;
using Simulator;

namespace SimConsole;

internal class LogVisulizer
{
    SimulationHistory Log { get; }
    public LogVisulizer(SimulationHistory log)
    {
        Log = log;
    }

    public void Draw(int turnIndex)
    {
        string Top = "";
        string Mid = "";
        string Bottom = "";
        for (int x = 0; x<= 2 * Log.SizeX; x++)
        {
            if (x == 0)
            {
                Top += Box.TopLeft;
                Mid += Box.MidLeft;
                Bottom += Box.BottomLeft;
            }
            else if (x == 2 * Log.SizeX)
            {
                Top += Box.TopRight;
                Mid += Box.MidRight;
                Bottom += Box.BottomRight;
            }
            else
            {
                if (x % 2 == 0)
                {
                    Top += Box.TopMid;
                    Mid += Box.Cross;
                    Bottom += Box.BottomMid;
                }
                else
                {
                    Top += Box.Horizontal;
                    Mid += Box.Horizontal;
                    Bottom += Box.Horizontal;
                }
            }
        }
        string Ekran = "";
        for (int y = Log.SizeY - 1; y >= 0; y--)
        {
            if (y == Log.SizeY - 1)
            {
                Ekran += Top;
            }
            else
            {
                Ekran += Mid;
            }
            Ekran += "\n";
            for (int x = 0; x < Log.SizeX; x++)
            {
                if (x == 0)
                {
                    Ekran += Box.Vertical;
                }
                char creatures = Log.TurnLogs[turnIndex].Symbols[new Simulator.Point (x, y)];
                if (creatures == null)
                {
                    Ekran += IMappableConsole.Null;
                }
                else
                {
                    Ekran += creatures;
                }
                Ekran += Box.Vertical;
            }
            Ekran += "\n";
            if (y == 0)
            {
                Ekran += Bottom;
            }
        }
        Console.Write(Ekran);
    }
}
