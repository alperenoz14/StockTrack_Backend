using StockTrack_Backed_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack_Backed_Core.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetOrdersByPlantIdAsync(int plantId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> AddOrderAsync(Order order);
        Order UpdateOrder(Order order);
        void RemoveOrder(int orderId);
    }
}
