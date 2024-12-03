using Simulator;
using Simulator.Maps;

namespace SimConsole;
public class MapVisualizer(Map map)
{
    public Map Map { get; } = map;

    public void Draw()
    {
        for (int y = 0; y < Map.SizeY; y++)
        {
            if (y == 0)
            {
                for (int x = 0; x <= 2*Map.SizeX; x++)
                {
                    if (x == 0)
                    {
                        Console.Write(Box.TopLeft);
                    }
                    else if (x == 2 * Map.SizeX)
                    {
                        Console.Write(Box.TopRight);
                    }
                    else
                    {
                        if (x % 2 == 0)
                        {
                            Console.Write(Box.TopMid);
                        }
                        else
                        {
                            Console.Write(Box.Horizontal);
                        }
                    }
                }
            }
            else 
            {
                for (int x = 0; x <= 2 * Map.SizeX; x++)
                {
                    if (x == 0)
                    {
                        Console.Write(Box.MidLeft);
                    }
                    else if (x == 2 * Map.SizeX)
                    {
                        Console.Write(Box.MidRight);
                    }
                    else
                    {
                        if (x % 2 == 0)
                        {
                            Console.Write(Box.Cross);
                        }
                        else
                        {
                            Console.Write(Box.Horizontal);
                        }
                    }
                }
            }
            Console.WriteLine();
            for (int x = 0; x < Map.SizeX; x++)
            {
                if (x == 0)
                {
                    Console.Write(Box.Vertical);
                }
                var creatures = Map.At(x, y);
                if (creatures == null)
                {
                    Console.Write(IMappableConsole.Null);
                }
                else if (creatures.Count != 1)
                {
                    Console.Write(IMappableConsole.Wiele);
                }
                else
                {
                    if (creatures[0] is Orc)
                    {
                        Console.Write(IMappableConsole.Orc);
                    }
                    else
                    {
                        Console.Write(IMappableConsole.Elf);
                    }
                }
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();
            if (y == Map.SizeY - 1)
            {
                for (int x = 0; x <= 2 * Map.SizeX; x++)
                {
                    if (x == 0)
                    {
                        Console.Write(Box.BottomLeft);
                    }
                    else if (x == 2 * Map.SizeX)
                    {
                        Console.Write(Box.BottomRight);
                    }
                    else
                    {
                        if (x % 2 == 0)
                        {
                            Console.Write(Box.BottomMid);
                        }
                        else
                        {
                            Console.Write(Box.Horizontal);
                        }
                    }
                }
            }
        }

    }
}
