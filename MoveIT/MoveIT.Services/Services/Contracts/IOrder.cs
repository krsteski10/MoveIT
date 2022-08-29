namespace MoveIT.Services.Services.Contracts;

public interface IOrder
{
    Task SaveOrder(Models.Order order);

    Task UpdateOrder(int id, Models.Order order);

    Task DeleteOrder(Models.Order order);

    Task<List<Models.Order>> ListOrdersAsync(string userId);

    Task<Models.Order> GetOrderDetails(int? id);

    Task<Models.Order> EditOrDeleteOrderDetails(int? id);

    bool GetOrderById(int? id);
}
