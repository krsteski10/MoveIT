using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveIT.Services.Services.Contracts;
using System.Security.Claims;

namespace MoveIT.App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IPriceCalculation _priceCalculation;
        private readonly IOrder _orderContext;

        public OrdersController(IPriceCalculation priceCalculation, IOrder orderContext)
        {
            _priceCalculation = priceCalculation;
            _orderContext = orderContext;
        }

        // GET: Orders
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = await _orderContext.ListOrdersAsync(userId);

            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var orderDetails = await _orderContext.GetOrderDetails(id);

            return View(orderDetails);
        }

        // GET: Orders/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Distance,LivingArea,BasementAtticArrea,NumberOfCars,Piano,TotalAmount,UserId")] MoveIT.Models.Order order)
        {           
            order.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                if (order.TotalAmount > 0)
                {
                    await _orderContext.SaveOrder(order);
                }
                else 
                { 
                    await _orderContext.SaveOrder(GetOrCreateOrder(order));
                }

                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/GetPrice
        public IActionResult GetMyPrice()
        {
            return View();
        }

        // POST: Orders/GetPriceCalculation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetOrderPrice(MoveIT.Models.Order order)
        {
            ModelState.Remove("NumberOfCars");
            ModelState.Remove("TotalAmount");

            var newOrder = GetOrCreateOrder(order);
         
            return View("ShowMyPrice", newOrder);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var order = await _orderContext.EditOrDeleteOrderDetails(id);

            return View(order);        
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Distance,LivingArea,BasementAtticArrea,NumberOfCars,Piano,TotalAmount")] MoveIT.Models.Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _orderContext.UpdateOrder(id, GetOrCreateOrder(order));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }

                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var order = await _orderContext.GetOrderDetails(id);

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _orderContext.EditOrDeleteOrderDetails(id);

            await _orderContext.DeleteOrder(order);

            return RedirectToAction(nameof(Index));        
        }

        private bool OrderExists(int id)
        {
            return _orderContext.GetOrderById(id);
        }

        /// <summary>
        /// Get or Create a new order with price and cars involved calculated
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private MoveIT.Models.Order GetOrCreateOrder(MoveIT.Models.Order order)
        {
            var newOrder = MoveIT.Models.Order.Map(order);
            newOrder.TotalAmount = _priceCalculation.GetTotalPrice(newOrder.Distance, newOrder.LivingArea, newOrder.BasementAtticArrea, newOrder.Piano, out int numberOfCars);
            newOrder.NumberOfCars = numberOfCars;

            return newOrder;
        }
    }
}
