using ClassificationOfPlants.src.Models;

namespace ClassificationOfPlants.src.Repositories.Interfaces;

public interface IPlantsRepository
{
    Task<Plant> getPlantById(int id);

    void CreatePlant(Plant plant);

    Task<List<Plant>> GetPlantsByGrowthLocation();

    Task <List<Plant>> GetPlantsByGrowthLocation(string location);

    Task<List<Plant> >GetPlantsBySize(bool param);

    Task<List<Plant>> GetPlantsBySize(double smallest, double largest);

    Task<List<Plant>> GetPlantsByForm();
}
