namespace ClassificationOfPlants.src.Models;

public class Plant
{
    public int _id { get; set; }
    public string ImagePath { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Form { get; set; }
    public double SizeInCM { get; set; }
    public string[] GrowthLocation { get; set; }

}