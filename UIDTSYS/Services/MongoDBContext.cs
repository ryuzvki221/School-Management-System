using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UIDTSYS.Models;

namespace UIDTSYS.Services
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;


        public MongoDBContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }

        // Get collection of ufrs
        public IMongoCollection<Ufr> Ufrs
        {
            get
            {
                return _database.GetCollection<Ufr>("ufrs");
            }
        }

         // Get collection of departements
         public IMongoCollection<Departement> Departements
        {
            get
            {
                return _database.GetCollection<Departement>("departements");
            }
        }
    }
}
