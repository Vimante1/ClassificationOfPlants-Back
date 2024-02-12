using ClassificationOfPlants.src.Models;
using ClassificationOfPlants.src.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Xml.Linq;

namespace ClassificationOfPlants.src.Repositories;

public class PlantRepository : BaseReporitory.BaseRepository<Plant>, IPlantsRepository
{
    public PlantRepository(IMongoDbSettings settings) : base(settings, "Plant") { }

    public async Task<Plant> getPlantById(int id)
    {
        var filter = Builders<Plant>.Filter.Eq("_id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public void CreatePlant(Plant plant)
    {
        _collection.InsertOne(plant);
    }

    public Task<List<Plant>> GetPlantsByGrowthLocation()
    {
        var sortedDocuments = _collection.Find(Builders<Plant>.Filter.Empty)
            .Sort(Builders<Plant>.Sort.Ascending(doc => doc.GrowthLocation))
            .ToListAsync();
        return sortedDocuments;
    }

    public async Task<List<Plant>> GetPlantsByGrowthLocation(string location)
    {
        var filter = Builders<Plant>.Filter.Regex(doc => doc.GrowthLocation, new BsonRegularExpression(location, "i"));
        var result = await _collection.Find(filter).ToListAsync();
        return result;
    }

    public async Task<List<Plant>> GetPlantsBySize(bool param)
    {
        var sortDefinition = param ? Builders<Plant>.Sort.Ascending(doc => doc.SizeInCM) : Builders<Plant>.Sort.Descending(doc => doc.SizeInCM);

        var result = await _collection.Find(Builders<Plant>.Filter.Empty)
            .Sort(sortDefinition)
            .ToListAsync();
        return result;
    }

    public async Task<List<Plant>> GetPlantsBySize(double smallest, double largest)
    {
        var filter = Builders<Plant>.Filter.And(
            Builders<Plant>.Filter.Gte(doc => doc.SizeInCM, smallest),
            Builders<Plant>.Filter.Lte(doc => doc.SizeInCM, largest)
        );

        var sortDefinition = Builders<Plant>.Sort.Ascending(doc => doc.SizeInCM);

        var result = await _collection.Find(filter)
            .Sort(sortDefinition)
            .ToListAsync();
        return result;
    }

    public Task<List<Plant>> GetPlantsByForm()
    {
        var sortedDocuments = _collection.Find(Builders<Plant>.Filter.Empty)
            .Sort(Builders<Plant>.Sort.Ascending(doc => doc.Form))
            .ToListAsync();
        return sortedDocuments;
    }

    public async Task<List<Plant>> GetPlantsByForm(string formName)
    {
        var filter = Builders<Plant>.Filter.Regex("Form", new BsonRegularExpression(formName, "i"));
        var plant = await _collection.Find(filter).ToListAsync();
        return plant;
    }

    public async Task<List<Plant>> GetThreeRandomPlant()
    {
        long totalDocuments = await _collection.CountDocumentsAsync(FilterDefinition<Plant>.Empty);

        Random random = new Random();
        List<int> randomIndexes = Enumerable.Range(0, 3).Select(_ => random.Next((int)totalDocuments)).ToList();

        List<Plant> result = new List<Plant>();

        foreach (var item in randomIndexes)
        {
            result.Add(await _collection.Find(Builders<Plant>.Filter.Eq("_id", item)).FirstOrDefaultAsync());
        }
        return result;
    }

    public async Task<List<Plant>> GetPlantsByName(string name)
    {
        var filter = Builders<Plant>.Filter.Regex("Name", new BsonRegularExpression(name, "i"));
        var plant = await _collection.Find(filter).ToListAsync();
        return plant;
    }
}