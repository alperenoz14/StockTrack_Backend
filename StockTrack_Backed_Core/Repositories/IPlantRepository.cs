using StockTrack_Backed_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack_Backed_Core.Repositories
{
    public interface IPlantRepository
    {
        Task<List<Plant>> GetAllPlantsAsync();
        Task<Plant> GetPlantByPlantIdAsync(int plantId);
        Task<List<Plant>> AddPlantsAsync(List<Plant> plants);

    }
}
