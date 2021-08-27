using Microsoft.EntityFrameworkCore;
using StockTrack_Backed_Core.Models;
using StockTrack_Backed_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack_Backend_Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;
        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProductAsync(Product Product)
        {
            await _context.Products.AddAsync(Product);
            await _context.SaveChangesAsync();
            return Product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }
    }
}
