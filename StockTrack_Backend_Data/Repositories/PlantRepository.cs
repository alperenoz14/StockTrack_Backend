using Microsoft.EntityFrameworkCore;
using StockTrack_Backed_Core.Models;
using StockTrack_Backed_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack_Backend_Data.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly AppDBContext _context;
        //private readonly DbSet<Plant> _dbSet;
        public PlantRepository(AppDBContext context)
        {
            _context = context;
            //_dbSet = context.Set<Plant>();
            
        }

        public async Task<List<Plant>> AddPlantsAsync(List<Plant> plants)
        {
            await _context.Plants.AddRangeAsync(plants);
            await _context.SaveChangesAsync();
            return plants;
        }

        public async Task<List<Plant>> GetAllPlantsAsync()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant> GetPlantByPlantIdAsync(int plantId)
        {
            return await _context.Plants.SingleOrDefaultAsync(x => x.PlantId == plantId);
        }
    }
}
