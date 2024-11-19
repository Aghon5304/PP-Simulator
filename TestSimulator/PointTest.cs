using Simulator;
using static Simulator.Directions;
namespace TestSimulator;


public class PointTest
{
    [Fact]
    public void PointToString_ShouldReturnCorrectString()
    {
        // Arrange
        int x = 10;
        int y = 20;
        // Act
        var point = new Point(x, y);
        // Assert
        Assert.Equal($"({x}, {y})", point.ToString());
    }
    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(5, 10, Direction.Down, 5, 9)]
    [InlineData(5, 10, Direction.Left, 4, 10)]
    [InlineData(5, 10, Direction.Right, 6, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var result = point.Next(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Fact]
    public void Next_InvalidDirection_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        var point = new Point(5, 10);
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            point.Next((Direction)4));
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(5, 10, Direction.Down, 4, 9)]
    [InlineData(5, 10, Direction.Left, 4, 11)]
    [InlineData(5, 10, Direction.Right, 6, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var result = point.NextDiagonal(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Fact]
    public void NextDiagonal_InvalidDirection_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        var point = new Point(5, 10);
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            point.NextDiagonal((Direction)4));
    }
}
