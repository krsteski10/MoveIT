using MoveIT.Services.Services.Contracts;

namespace MoveIT.Services.Services;

public class VolumePrice : IVolumePrice
{
    public int CalculateCarsForArea(int livingArea, int basementAtticArrea)
    {
        //Calculate cars based on area
        var areaSize = livingArea + basementAtticArrea * 2;
        return areaSize / 50 + 1;
    }
}
