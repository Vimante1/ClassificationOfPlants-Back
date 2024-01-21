using ClassificationOfPlants.src.Models;
using ClassificationOfPlants.src.Models.ViewModels;
using ClassificationOfPlants.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace ClassificationOfPlants.Controllers;

[ApiController]
[Route("Plant")]
public class PlantController : ControllerBase
{
    private readonly IPlantService _service;

    public PlantController(IPlantService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("Create")]
    public IActionResult Create([FromForm]PlantViewModel plant)
    {
        _service.CreatePlant(plant);
        return Ok();
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.getPlantById(id);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetByGrowthLocation")]
    public async Task<IActionResult> GetByGrowthLocation()
    {
        var result = await _service.GetPlantsByGrowthLocation();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetByGrowthLocationHandler")]
    public async Task<IActionResult> GetByGrowthLocation(string location)
    {
        var result = await _service.GetPlantsByGrowthLocation(location);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetPlantsBySizeSortedByParam")]
    public async Task<IActionResult> GetPlantsBySize(bool param)
    {
        return Ok(await _service.GetPlantsBySize(param));
    }
    [HttpGet]
    [Route("GetPlantsBySizeSortedHandler")]
    public async Task<IActionResult> GetPlantsBySize(double smallest, double largest)
    {
        return Ok(await _service.GetPlantsBySize(smallest, largest));
    }

    [HttpGet]
    [Route("GetPlantsByForm")]
    public async Task<IActionResult> GetPlantsByForm()
    {
        return Ok(await _service.GetPlantsByForm());
    }

    [HttpGet]
    [Route("ThreeRandom")]
    public async Task<IActionResult> ThreeRandom()
    {
        return Ok(await _service.GetThreeRandomPlant());
    }
}