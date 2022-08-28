using MoveIT.Services.Services;
using MoveIT.Services.Services.Contracts;
using Xunit;

namespace MoveITappTests
{
    public class DistanceTests
    {
        private readonly IDistancePrice _distanceCalculation;

        public DistanceTests()
        {
            _distanceCalculation = new DistancePrice();
        }

        [Fact]
        public void CalculateDistancePrice_GivenDistance10km_ExpectedPrice1100SEK()
        {
            // Arrange
            int distance = 10;

            // Act
            var distancePrice = _distanceCalculation.CalculateDistancePrice(distance);

            // Assert
            Assert.Equal(1100, distancePrice);
        }

        [Fact]
        public void CalculateDistancePrice_GivenDistance99km_ExpectedPrice5792SEK()
        {
            // Arrange
            int distance = 99;

            // Act
            var distancePrice = _distanceCalculation.CalculateDistancePrice(distance);

            // Assert
            Assert.Equal(5792, distancePrice);
        }
    }
}
