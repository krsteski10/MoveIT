using MoveIT.Services.Services.Contracts;

namespace MoveIT.Services.Services;

public class PriceCalculation : IPriceCalculation
{
    private readonly IDistancePrice _distancePrice;
    private readonly IVolumePrice _volumePrice;

    public PriceCalculation(IDistancePrice distancePrice, IVolumePrice volumePrice)
    {
        _distancePrice = distancePrice;
        _volumePrice = volumePrice;
    }

    public int GetTotalPrice(int distance, int livingArea, int basementAtticArrea, bool piano, out int numberOfCars)
    {
        //Calculate totalAmount based on distance and cars involved
        var distancePrice = _distancePrice.CalculateDistancePrice(distance);

        numberOfCars = _volumePrice.CalculateCarsForArea(livingArea, basementAtticArrea);

        var totalAmount = distancePrice * numberOfCars;

        //Add extra 5000 if Piano is involved
        if (piano)
        {
            totalAmount += 5000;
        }

        return totalAmount;
    }
}
