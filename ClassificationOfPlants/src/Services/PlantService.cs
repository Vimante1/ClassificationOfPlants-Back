using ClassificationOfPlants.src.Models;
using ClassificationOfPlants.src.Models.ViewModels;
using ClassificationOfPlants.src.Repositories.Interfaces;
using ClassificationOfPlants.src.Services.Interfaces;

namespace ClassificationOfPlants.src.Services;

public class PlantService : IPlantService
{
    private readonly IPlantsRepository _repository;

    public PlantService(IPlantsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plant> getPlantById(int id)
    {
        return await _repository.getPlantById(id);
    }

    public void CreatePlant(PlantViewModel plant)
    {
        Plant outPlant = new Plant();
        try
        {
            if (plant.Image != null && plant.Image.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(plant.Image.FileName)}";

                var imagePath = Path.Combine("C:/Users/Viman/OneDrive/Desktop/PlantPhoto", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    plant.Image.CopyTo(stream);
                }
                outPlant = new Plant()
                {
                    _id = plant._id,
                    Name = plant.Name,
                    Description = plant.Description,
                    Form = plant.Form,
                    GrowthLocation = plant.GrowthLocation,
                    SizeInCM = plant.SizeInCM,
                    ImagePath = imagePath
                };
            }
            else
            {
                Console.WriteLine("Bad request");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Wrong");
        }

        
        _repository.CreatePlant(outPlant);
    }

    public async Task<List<Plant>> GetThreeRandomPlant()
    {
        return await _repository.GetThreeRandomPlant();
    }

    public async Task<List<Plant>> GetPlantsByForm()
    {
        return await _repository.GetPlantsByForm();
    }

    public async Task<List<Plant>> GetPlantsByGrowthLocation()
    {
        return await _repository.GetPlantsByGrowthLocation();
    }

    public async Task<List<Plant>> GetPlantsByGrowthLocation(string location)
    {
        return await _repository.GetPlantsByGrowthLocation(location);
    }

    public async Task<List<Plant>> GetPlantsBySize(bool param)
    {
        return await _repository.GetPlantsBySize(param);
    }

    public async Task<List<Plant>> GetPlantsBySize(double smallest, double largest)
    {
        return await _repository.GetPlantsBySize(smallest, largest);
    }
}