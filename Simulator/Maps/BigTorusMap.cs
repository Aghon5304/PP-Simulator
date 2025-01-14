namespace Simulator.Maps;

internal class BigTorusMap : SmallMap
{
	public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
	{
		FNext = NextRules.TorusNext;
		FNextDiagonal = NextRules.TorusNextDiagonal;
	}
}
