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
        /// Deleting departement
        /// </summary>
        /// <param name="departementIn"></param>
        /// <returns></returns>
        public void Delete(Departement departementIn)
        {
            _context.Departements.DeleteOne(departement => departement.Id == departementIn.Id);
        }

        public void Delete(string id)
        {
            var filter = Builders<Departement>.Filter.Eq("Id", id);
            _context.Departements.DeleteOne(filter);
        }



        /// <summary>
        /// Search departement
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<Departement> Search(string search)
        {
            IQueryable<Departement> query = from departement in _context.Departements.AsQueryable()
                                    where departement.Name.Contains(search)
                                    select departement;

           if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(departement => departement.Name.Contains(search));
            }

            return query.ToList();

        }
    }
}
