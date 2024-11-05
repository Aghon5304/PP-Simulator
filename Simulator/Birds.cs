using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

internal class Birds:Animals
{
    public Boolean CanFly { get; set; } = true;
    public Birds(string Description, uint Size, Boolean canFly) : base(Description, Size)
    {
        CanFly = canFly;
    }
    public Birds() : base() { }
    public override string Info
    {
        get { return $"{Description}(fly{(CanFly == true ? '+' : '-')}) <{Size}>"; }
    }
}
