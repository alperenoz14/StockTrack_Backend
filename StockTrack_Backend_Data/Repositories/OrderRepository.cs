using Microsoft.EntityFrameworkCore;
using StockTrack_Backed_Core.Models;
using StockTrack_Backed_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack_Backend_Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _context;
        public OrderRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetOrdersByPlantIdAsync(int plantId)
        {
            return await _context.Orders.Where(x => x.PlantId == plantId).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public void RemoveOrder(int orderId)
        {
            var ordertoRemove = _context.Orders.Find(orderId);
            _context.Orders.Remove(ordertoRemove);
            _context.SaveChanges();
        }

        public Order UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order;
        }
    }
}
