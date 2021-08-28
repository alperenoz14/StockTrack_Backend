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
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly IPlantService _plantService;
        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlants()
        {
            var plants = await _plantService.GetAllPlantsAsync();

            if (plants is not null) { return Ok(plants); } else { return StatusCode(500); }
            
        }

        [HttpGet("{plantId}")]
        public async Task<IActionResult> GetPlantByPlantId(int plantId)
        {
            var plant = await _plantService.GetPlantByPlantIdAsync(plantId);

            if (plant is not null) { return Ok(plant); } else { return NotFound(); }

        }

        [HttpPost]
        public async Task<IActionResult> AddPlants(List<Plant> plants)
        {
            var addedPlants = await _plantService.AddPlantsAsync(plants);

            if (addedPlants is not null) { return Ok(addedPlants); } else { return StatusCode(500); }
        }
    }
}
