using ClassificationOfPlants.src.Repositories.Interfaces;

namespace ClassificationOfPlants.src.Models

{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}