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
            _description = Walidatory.Shortener(value, 3, 15, '#');
        }
    }
    public uint Size { get; set; }

    public Animals(string description = "Unknown", uint size = 3)
    {
        Description = description;
        Size = size > 1 ? size : 1;
    }

    public virtual string Info => $"{Description} <{Size}>";
    public override string? ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}