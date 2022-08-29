using MoveIT.Services.Services.Contracts;

namespace MoveIT.Services.Services;

public class Order : IOrder
{

    private readonly IOrderRepository _orderContext;

    public Order(IOrderRepository orderContext)
    {
        _orderContext = orderContext;
    }

    public async Task SaveOrder(Models.Order order)
    {
        await _orderContext.SaveOrder(order);
    }

    public async Task UpdateOrder(int id, Models.Order order)
    {
        await _orderContext.UpdateOrder(id, order);
    }

    public async Task DeleteOrder(Models.Order order)
    {
        await _orderContext.DeleteOrder(order);
    }

    public async Task<List<Models.Order>> ListOrdersAsync(string userId)
    {
        return await _orderContext.ListOrdersAsync(userId);
    }

    public async Task<Models.Order> GetOrderDetails(int? id)
    {
        return await _orderContext.GetOrderDetails(id);
    }

    public async Task<Models.Order> EditOrDeleteOrderDetails(int? id)
    {
        return await _orderContext.EditOrDeleteOrderDetails(id);
    }

    public bool GetOrderById(int? id)
    {
        return _orderContext.GetOrderById(id);
    }
}
