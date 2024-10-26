using System.ComponentModel;

namespace Simulator;

public class Animals
{
    private string _description = "Unknown";
    public required string Description
    {
        get => _description;
        init
        {
            value = value.Trim();
            if (value.Length > 15)
                value = value[0..15].Trim();
            if (value.Length < 3)
                value = value.PadRight(3, '#');
            _description = char.ToUpper(value[0]) + value[1..];
        }
    }
    public uint Size { get; set; }

    public Animals(string description = "Unknown", uint size = 3)
    {
        Description = description;
        if (size < 1)
            size = 1;
        Size = size;
    }

    public string Info => $"{Description} ({Size})";
}