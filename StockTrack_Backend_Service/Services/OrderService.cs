using StockTrack_Backed_Core.Models;
using StockTrack_Backed_Core.Repositories;
using StockTrack_Backed_Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack_Backend_Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            return await _orderRepository.AddOrderAsync(order);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task<List<Order>> GetOrdersByPlantIdAsync(int plantId)
        {
            return await _orderRepository.GetOrdersByPlantIdAsync(plantId);
        }

        public void RemoveOrder(int orderId)
        {
            _orderRepository.RemoveOrder(orderId);
        }

        public Order UpdateOrder(Order order)
        {
            return _orderRepository.UpdateOrder(order);
        }
    }
}
