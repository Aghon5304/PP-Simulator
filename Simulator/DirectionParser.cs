namespace Simulator;

public class DirectionParser
{
    public static Directions.Direction[] Parse(string direction)
    {
        List<Directions.Direction> result = [];
        foreach (char x in direction)
        {
            char letter = char.ToLower(x);
            if (letter == 'u')
            {
                result.Add(Directions.Direction.Up);
            }
            else if (letter == 'r')
            {
                result.Add(Directions.Direction.Right);
            }
            else if (letter == 'l')
            {
                result.Add(Directions.Direction.Left);
            }
            else if (letter == 'd')
            {
                result.Add(Directions.Direction.Down);
            }
        }
        return [.. result];
    }
}

