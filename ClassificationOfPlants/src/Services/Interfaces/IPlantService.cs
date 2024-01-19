using ClassificationOfPlants.src.Models;
using ClassificationOfPlants.src.Models.ViewModels;

namespace ClassificationOfPlants.src.Services.Interfaces;

public interface IPlantService
{
    Task<Plant> getPlantById(int id);
    
    void CreatePlant(PlantViewModel plant);

    Task <List<Plant>> GetPlantsByForm();

    Task<List<Plant>>GetPlantsByGrowthLocation();
    
    Task <List<Plant>> GetPlantsByGrowthLocation(string location);
    
    /// <summary>
    /// Sort the plants from smallest to largest
    /// </summary>
    /// <param name="param">true - from smallest to largest; false - from largest to smallest</param>
    /// <returns></returns>
    Task <List<Plant>> GetPlantsBySize(bool param);
 
    /// <summary>
    /// Get plants according to the size with the set values.
    /// </summary>
    /// <param name="smallest">The smallest value to search for</param>
    /// <param name="largest">The largest value to search for</param>
    /// <returns></returns>
    Task<List<Plant>> GetPlantsBySize(double smallest, double largest);
}
