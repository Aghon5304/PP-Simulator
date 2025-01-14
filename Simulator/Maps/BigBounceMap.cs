using Direction = Simulator.Directions.Direction;
namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
	public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
	{
		FNext = NextRules.BounceNext;
		FNextDiagonal = NextRules.BounceNextDiagonal;
	}
}
