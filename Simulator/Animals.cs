namespace Simulator;

public class Animals
{
    public required string Description { get; init; }
    public uint Size { get; set; } = 3;

    public void Info()
    {
        Console.WriteLine($"{Description} <{Size}>");
    }
}