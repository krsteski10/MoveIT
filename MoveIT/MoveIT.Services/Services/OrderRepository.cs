using Microsoft.EntityFrameworkCore;
using MoteIT.DataLayer.Data;
using MoveIT.Services.Services.Contracts;

namespace MoveIT.Services.Services;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveOrder(Models.Order order)
    {
        _context.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateOrder(int id, Models.Order order)
    {
        _context.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrder(Models.Order order)
    {
        _context.Order.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Models.Order>> ListOrdersAsync(string userId)
    {
        var orders = await _context.Order.Where(user => user.UserId == userId).ToListAsync();

        return orders;
    }

    public async Task<Models.Order> GetOrderDetails(int? id)
    {  
        if (id == null || _context.Order == null)
        {
            throw new NotImplementedException();
        }

        var orderDetails = await _context.Order.FirstOrDefaultAsync(m => m.Id == id);

        if (orderDetails == null)
        {
            throw new NotImplementedException();
        }

        return orderDetails;
    }

    public async Task<Models.Order> EditOrDeleteOrderDetails(int? id)
    {
        if (id == null || _context.Order == null)
        {
            throw new NotImplementedException();
        }

        var order = await _context.Order.FindAsync(id);

        if (order == null)
        {
            throw new NotImplementedException();
        }

        return order;
    }

    public bool GetOrderById(int? id)
    {
        return (_context.Order?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
