namespace MoveIT.Models;

public class Order
{
    public int Id { get; set; }
    public int Distance { get; set; }
    public int LivingArea { get; set; }
    public int BasementAtticArrea { get; set; }
    public int NumberOfCars { get; set; }
    public bool Piano { get; set; }
    public int TotalAmount { get; set; }
    public string? UserId { get; set; }

    public Order()
    {

    }

    public static Order Map(Order order)
    {
        var newOrder = new Order
        {
            Id = order.Id,
            Distance = order.Distance,
            LivingArea = order.LivingArea,
            BasementAtticArrea = order.BasementAtticArrea,
            Piano = order.Piano,
            UserId = order.UserId
        };

        return newOrder;
    }
}