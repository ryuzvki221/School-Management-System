using MongoDB.Driver;
using Microsoft.Extensions.Options;

using UIDTSYS.Models;

namespace UIDTSYS.Services
{
    public class DepartementService 
    {

        private readonly MongoDBContext _context;

        public DepartementService(IOptions<Settings> settings)
        {
            _context = new MongoDBContext(settings);
        }

        /// <summary>
        /// Retrieving departements details
        /// </summary>
        /// <returns></returns>
        public List<Departement> Get()
        {
            return _context.Departements.Find(_ => true).ToList();
        }

        /// <summary>
        /// Retrieving departement details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Departement Get(string id)
        {
            var filter = Builders<Departement>.Filter.Eq("Id", id);

            return _context.Departements.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Creating departement
        /// </summary>
        /// <param name="departement"></param>
        /// <returns></returns>
        public Departement Create(Departement departement)
        {
            _context.Departements.InsertOne(departement);
            return departement;
        }

        /// <summary>
        /// Updating departement details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departementIn"></param>
        public void Update(string id, Departement departementIn)
        {
            _context.Departements.ReplaceOne(departement => departement.Id == id, departementIn);
        }

        /// <summary>
        /// Removing departement
        /// </summary>
        /// <param name="departementIn"></param>
        public void Delete(Departement departementIn)
        {
            _context.Departements.DeleteOne(departement => departement.Id == departementIn.Id);
        }

        /// <summary>
        /// Removing departement by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            _context.Departements.DeleteOne(departement => departement.Id == id);
        }


        /// <summary>
        /// Retrieving departements details by UfrId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public List<Departement> GetByUfrId(string id)
        {
            var filter = Builders<Departement>.Filter.Eq("UfrId", id);
            return _context.Departements.Find(filter).ToList();
        }
    }
}