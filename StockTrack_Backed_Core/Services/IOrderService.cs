using StockTrack_Backed_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack_Backed_Core.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetOrdersByPlantIdAsync(int plantId);
        Task<Order> AddOrderAsync(Order order);
        Order UpdateOrder(Order order);
        void RemoveOrder(int orderId);
    }
}
