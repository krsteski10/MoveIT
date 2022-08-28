using MoveIT.Services.Services;
using MoveIT.Services.Services.Contracts;
using Xunit;

namespace MoveITappTests
{
    public class TotalAmountTests
    {
        private readonly IPriceCalculation _priceCalculation;
        private readonly IDistancePrice _distancePrice;
        private readonly IVolumePrice _volumePrice;

        public TotalAmountTests()
        {
            _distancePrice = new DistancePrice();
            _volumePrice = new VolumePrice();
            _priceCalculation = new PriceCalculation(_distancePrice, _volumePrice);
        }

        [Fact]
        public void GetTotalPrice_GivenDistance50_ExpectedTotalAmount5400SEK()
        {
            // Arrange
            int distance = 50;
            int livingArea = 49;
            int basementAtticArrea = 0;
            bool piano = false;

            // Act
            var totalAmount = _priceCalculation.GetTotalPrice(distance, livingArea, basementAtticArrea, piano, out _);

            // Assert
            Assert.Equal(5400, totalAmount);
        }

        [Fact]
        public void GetTotalPrice_GivenDistance100Area70_ExpectedTotalAmount21400SEK()
        {
            // Arrange
            int distance = 100;
            int livingArea = 20;
            int basementAtticArrea = 25;
            bool piano = false;

            // Act
            var totalAmount = _priceCalculation.GetTotalPrice(distance, livingArea, basementAtticArrea, piano, out _);

            // Assert
            Assert.Equal(21400, totalAmount);
        }

        [Fact]
        public void GetTotalPrice_GivenDistance10kmWithPiano_ExpectedTotalAmount()
        {
            // Arrange
            int distance = 10;
            int livingArea = 40;
            int basementAtticArrea = 0;
            bool piano = true;

            // Act
            var totalAmount = _priceCalculation.GetTotalPrice(distance, livingArea, basementAtticArrea, piano, out _);

            // Assert
            Assert.Equal(6100, totalAmount);       
        }
    }
}
