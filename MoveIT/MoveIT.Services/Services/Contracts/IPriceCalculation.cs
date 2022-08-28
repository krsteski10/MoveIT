namespace MoveIT.Services.Services.Contracts;

public interface IPriceCalculation
{
    int GetTotalPrice(int distance, int livingArea, int basementAtticArrea, bool piano, out int numberOfCars);
}
