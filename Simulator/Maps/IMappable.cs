using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Simulator.Maps;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Elf), nameof(Elf))]
[JsonDerivedType(typeof(Orc), nameof(Orc))]
[JsonDerivedType(typeof(Animals), nameof(Animals))]
[JsonDerivedType(typeof(Birds), nameof(Birds))]
public interface IMappable
{
    Map? Map { get; }
    Point Position { get; }
    string ToString();
    void Go(Directions.Direction Direction);
    void InitMapAndPosition(Map map, Point position);

    char Symbol { get; init; }
}
