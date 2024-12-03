using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Xml.Linq;
using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public Boolean CanFly { get; set; }
    public override char Symbol { get; init; }
    public Birds(string Description = "Unknown", uint Size = 3, Boolean canFly = true) : base(Description,Size)
    {
        CanFly = canFly;
        if (CanFly == false)
        {
            Symbol = 'b';
        }
        else
        {
            Symbol = 'B';
        }
    }
    public Birds() : base() { }
    public override string Info
    {
        get { return $"{Description}(fly{(CanFly == true ? '+' : '-')}) <{Size}>"; }
    }
}
