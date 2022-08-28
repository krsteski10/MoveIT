using MoveIT.Services.Services.Contracts;

namespace MoveIT.Services.Services;

public class DistancePrice : IDistancePrice
{
    public int CalculateDistancePrice(int distance)
    {
        var distancePrice = 0;

        //Calculate price based on distance
        if (distance < 50)
        {
            distancePrice = distance * 10 + 1000;
        }
        else if (distance >= 50 && distance < 100)
        {
            distancePrice = distance * 8 + 5000;
        }
        else
        {
            distancePrice = distance * 7 + 10000;
        }

        return distancePrice;
    }
}
