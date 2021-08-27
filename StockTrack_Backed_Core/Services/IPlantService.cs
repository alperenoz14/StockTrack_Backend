using StockTrack_Backed_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack_Backed_Core.Services
{
    public interface IPlantService
    {
        Task<List<Plant>> GetAllPlantsAsync();
        Task<Plant> GetPlantByIdAsync(int plantId);
        Task<List<Plant>> AddPlantsAsync(List<Plant> plants);
    }
}
