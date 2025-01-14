
namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
	public SmallSquareMap(int size) : base(size, size)
	{
		FNext = NextRules.WallNext;
		FNextDiagonal = NextRules.WallNextDiagonal;
	}
}
