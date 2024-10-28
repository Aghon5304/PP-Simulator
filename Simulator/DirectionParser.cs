namespace Simulator;

public class DirectionParser
{
    public static Directions.Direction[] Parse(string direction)
    {
        Stack<Directions.Direction> result = new();
        foreach (char x in direction)
        {
            char letter = char.ToLower(x);
            if (letter == 'u')
            {
                result.Push(Directions.Direction.Up);
            }
            else if (letter == 'r')
            {
                result.Push(Directions.Direction.Right);
            }
            else if (letter == 'l')
            {
                result.Push(Directions.Direction.Left);
            }
            else if (letter == 'd')
            {
                result.Push(Directions.Direction.Down);
            }
        }
        return [.. result.Reverse()];
    }
}

