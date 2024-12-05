using Simulator;
using Simulator.Maps;

namespace SimConsole;
public class MapVisualizer(Map map)
{
    public Map Map { get; } = map;

    public void Draw()
    {
        string Top = "";
        string Mid = "";
        string Bottom = "";
        for (int x = 0; x <= 2 * Map.SizeX; x++)
        {
            if (x == 0)
            {
                Top +=Box.TopLeft;
                Mid += Box.MidLeft;
                Bottom += Box.BottomLeft;
            }
            else if (x == 2 * Map.SizeX)
            {
                Top += Box.TopRight;
                Mid += Box.MidRight;
                Bottom += Box.BottomRight;
            }
            else
            {
                if (x % 2 == 0)
                {
                    Top+=Box.TopMid;
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
        for (int y = Map.SizeY-1; y >= 0; y--)
        {
            if (y == Map.SizeY-1)
            {
                Ekran += Top;
            }
            else 
            {
                Ekran += Mid;
            }
                Ekran +="\n";
            for (int x = 0; x < Map.SizeX; x++)
            {
                if (x == 0)
                {
                    Ekran+=Box.Vertical;
                }
                var creatures = Map.At(x, y);
                if (creatures == null)
                {
                    Ekran+=IMappableConsole.Null;
                }
                else if (creatures.Count != 1)
                {
                    Ekran+=IMappableConsole.Wiele;
                }
                else
                {
                    Ekran += creatures[0].Symbol;
                }
                Ekran += Box.Vertical;
            }
            Ekran += "\n";
            if (y == 0)
            {
                Ekran += Bottom;
            }
        }
        Console.WriteLine(Ekran);
    }
}
