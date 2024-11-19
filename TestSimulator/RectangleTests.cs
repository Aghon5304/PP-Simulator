using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using Simulator;
namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldSetCoordinates()
    {
        // Arrange
        int x1 = 1;
        int y1 = 2;
        int x2 = 3;
        int y2 = 4;
        // Act
        var rectangle = new Rectangle(x1, y1, x2, y2);
        // Assert
        Assert.Equal(x1, rectangle.X1);
        Assert.Equal(y1, rectangle.Y1);
        Assert.Equal(x2, rectangle.X2);
        Assert.Equal(y2, rectangle.Y2);
    }
    [Fact]
    public void ThorwArgumentException_WhenCoordinatesDoNotMakeRectangle()
    {
        // Arrange
        int x1 = 1;
        int y1 = 2;
        int x2 = 1;
        int y2 = 4;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }
    [Fact]
    public void ConstructorWithPoint_ValidCoordinates_ShouldSetCoordinates()
    {
        // Arrange
        int x1 = 1;
        int y1 = 2;
        Point point = new Point(x1, y1);
        int x2 = 3;
        int y2 = 4;
        Point point2 = new Point(x2, y2);
        // Act
        var rectangle = new Rectangle(point, point2);
        // Assert
        Assert.Equal(x1, rectangle.X1);
        Assert.Equal(y1, rectangle.Y1);
        Assert.Equal(x2, rectangle.X2);
        Assert.Equal(y2, rectangle.Y2);
    }
    [Fact]
    public void ToString_validStringOutput()
    {
        // Arrange
        int x1 = 1;
        int y1 = 2;
        int x2 = 3;
        int y2 = 4;
        // Act
        var rectangle = new Rectangle(x1,y1,x2,y2);
        // Assert
        Assert.Equal($"({x1}, {y1}):({x2}, {y2})", rectangle.ToString());
    }
    [Theory]
    [InlineData(1, 2, 3, 4, 2, 3, true)]
    [InlineData(1, 2, 3, 4, 1, 4, true)]
    [InlineData(1, 2, 3, 4, 4, 2, false)]
    public void Contains_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2, int x, int y, bool expected)
    {
        // Arrange
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(x, y);
        // Act
        var result = rectangle.Contains(point);
        // Assert
        Assert.Equal(expected, result);
    }
}
