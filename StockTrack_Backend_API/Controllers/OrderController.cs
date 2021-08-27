using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrack_Backed_Core.Models;
using StockTrack_Backed_Core.Services;
using StockTrack_Backend_Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrack_Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            if (orders is not null) { return Ok(orders); } else { return StatusCode(500); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order is not null) { return Ok(order); } else { return NotFound(); }
        }

        [HttpGet]
        [Route("GetOrdersByPlantId/{plantid}")]
        public async Task<IActionResult> GetOrdersByPlantId(int plantid)
        {
            var orders = await _orderService.GetOrdersByPlantIdAsync(plantid);

            if (orders is not null) { return Ok(orders); } else { return StatusCode(500); }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            var newOrder = await _orderService.AddOrderAsync(order);

            if (newOrder is not null) { return Ok(newOrder); } else { return StatusCode(500); }
        }

        [HttpPut]
        public  IActionResult UpdateOrder(Order order)
        {
            var updatedOrder =  _orderService.UpdateOrder(order);

            if(updatedOrder is not null) { return Ok(updatedOrder); } else { return StatusCode(500); }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveOrder(int id)
        {
            _orderService.RemoveOrder(id);
            return Ok();
        }

    }
}
