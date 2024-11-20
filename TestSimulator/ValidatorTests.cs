using Simulator;

namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(3, 4, 5, 4)]
        [InlineData(6, 4, 5, 5)]
        public void Limiter_ShouldReturnMinAndMaxValue(int value,int min,int max,int expected)
        {
            Assert.Equal(expected, Walidatory.Limiter(value, min, max));
        }
        [Theory]
        [InlineData("ala", 4, 5, '#', "Ala#")]
        [InlineData("Ala ma kota", 4, 5, '#',"Ala m")]
        [InlineData("Ala              ma                                kota", 4, 5, '#', "Ala#")]
        public void Shortener_ShouldReturnMinAndMaxValue(string value, int min, int max,char placeholder, string expected)
        {
            Assert.Equal(expected, Walidatory.Shortener(value, min, max,placeholder));
        }
    }
}
