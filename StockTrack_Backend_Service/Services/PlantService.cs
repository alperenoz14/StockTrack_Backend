using StockTrack_Backed_Core.Models;
using StockTrack_Backed_Core.Repositories;
using StockTrack_Backed_Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack_Backend_Service.Services
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        public PlantService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }
        public async Task<List<Plant>> AddPlantsAsync(List<Plant> plants)
        {
            return await _plantRepository.AddPlantsAsync(plants);
        }

        public async Task<List<Plant>> GetAllPlantsAsync()
        {
            return await _plantRepository.GetAllPlantsAsync();
        }

        public async Task<Plant> GetPlantByIdAsync(int plantId)
        {
            return await _plantRepository.GetPlantByIdAsync(plantId);
        }
    }
}
