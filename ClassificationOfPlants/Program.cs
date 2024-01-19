
using ClassificationOfPlants.src.Models;
using ClassificationOfPlants.src.Repositories;
using ClassificationOfPlants.src.Repositories.Interfaces;
using ClassificationOfPlants.src.Services;
using ClassificationOfPlants.src.Services.Interfaces;

namespace ClassificationOfPlants
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddScoped<IMongoDbSettings>(sp =>
            {
                var conf = builder.Configuration.GetSection("MongoDbConnection");
                return new MongoDbSettings
                {
                    ConnectionString = conf.GetValue<string>("ConnectionString"),
                    DatabaseName = conf.GetValue<string>("DatabaseName")
                };
            });

            


            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            builder.Services.AddScoped<IPlantsRepository, PlantRepository>();
            builder.Services.AddScoped<IPlantService, PlantService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.MapControllers();
            app.UseAuthorization();

            app.Run();
        }
    }
}