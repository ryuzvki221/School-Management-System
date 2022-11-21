using MongoDB.Driver;
using Microsoft.Extensions.Options;

using UIDTSYS.Models;

namespace UIDTSYS.Services
{
    public class FiliereService 
    {

        private readonly MongoDBContext _context;

        public FiliereService(IOptions<Settings> settings)
        {
            _context = new MongoDBContext(settings);
        }

        /// <summary>
        /// Retrieving filieres details
        /// </summary>
        /// <returns></returns>
        public List<Filiere> Get()
        {
            return _context.Filieres.Find(_ => true).ToList();
        }

        /// <summary>
        /// Retrieving filiere details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Filiere Get(string id)
        {
            var filter = Builders<Filiere>.Filter.Eq("Id", id);

            return _context.Filieres.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Creating filiere
        /// </summary>
        /// <param name="filiere"></param>
        /// <returns></returns>
        public Filiere Create(Filiere filiere)
        {
            _context.Filieres.InsertOne(filiere);
            return filiere;
        }

        /// <summary>
        /// Updating filiere details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filiereIn"></param>
        public void Update(string id, Filiere filiereIn)
        {
            _context.Filieres.ReplaceOne(filiere => filiere.Id == id, filiereIn);
        }

        /// <summary>
        /// Deleting filiere
        /// </summary>
        /// <param name="filiereIn"></param>
        public void Delete(Filiere filiereIn)
        {
            _context.Filieres.DeleteOne(filiere => filiere.Id == filiereIn.Id);
        }

        /// <summary>
        /// Deleting filiere
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            _context.Filieres.DeleteOne(filiere => filiere.Id == id);
        }

      
      /// <summary>
        /// Retrieving filiere by Departement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Filiere> GetByDepartement(string id)
        {
            var filter = Builders<Filiere>.Filter.Eq("DepartementId", id);

            return _context.Filieres.Find(filter).ToList();
        }

    }
}