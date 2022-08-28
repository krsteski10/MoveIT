using MoveIT.Services.Services;
using MoveIT.Services.Services.Contracts;
using Xunit;

namespace MoveITappTests
{
    public class VolumeTests
    {
        private readonly IVolumePrice _volumeCalculation;

        public VolumeTests()
        {
            _volumeCalculation = new VolumePrice();
        }

        [Fact]
        public void CalculateCarsForArea_LivingArea100_ExpectedCars3()
        {
            // Arrange
            int livingArea = 100;
            int basementAtticArrea = 0;

            // Act
            var numberOfCars = _volumeCalculation.CalculateCarsForArea(livingArea, basementAtticArrea);

            // Assert
            Assert.Equal(3, numberOfCars);
        }

        [Fact]
        public void CalculateCarsForArea_LivingArea170_ExpectedCars4()
        {
            // Arrange
            int livingArea = 70;
            int basementAtticArrea = 50;

            // Act
            var numberOfCars = _volumeCalculation.CalculateCarsForArea(livingArea, basementAtticArrea);

            // Assert
            Assert.Equal(4, numberOfCars);
        }
    }
}
