using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrack_Backed_Core.Models;
using StockTrack_Backed_Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrack_Backend_API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            if (products is not null) { return Ok(products); } else { return StatusCode(500); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product is not null) { return Ok(product); } else { return NotFound(); }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var addedProd = await _productService.AddProductAsync(product);

            if (addedProd is not null) { return Ok(addedProd); } else { return StatusCode(500); }
        }
    }
}
