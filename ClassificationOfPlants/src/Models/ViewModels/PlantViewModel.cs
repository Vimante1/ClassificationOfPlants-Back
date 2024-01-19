namespace ClassificationOfPlants.src.Models.ViewModels;

public class PlantViewModel
{

    public int _id { get; set; }
    public IFormFile Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Form { get; set; }
    public double SizeInCM { get; set; }
    public string[] GrowthLocation { get; set; }

}
