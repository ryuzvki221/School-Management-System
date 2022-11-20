using MongoDB.Driver;
using Microsoft.Extensions.Options;

using UIDTSYS.Models;

namespace UIDTSYS.Services
{
    public class UfrService 
    {

        private readonly MongoDBContext _context;

        public UfrService(IOptions<Settings> settings)
        {
            _context = new MongoDBContext(settings);
        }

        /// <summary>
        /// Retrieving ufrs details
        /// </summary>
        /// <returns></returns>
        public List<Ufr> Get()
        {
            return _context.Ufrs.Find(_ => true).ToList();
        }

        /// <summary>
        /// Retrieving ufr details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Ufr Get(string id)
        {
            var filter = Builders<Ufr>.Filter.Eq("Id", id);

            return _context.Ufrs.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Creating ufr
        /// </summary>
        /// <param name="ufr"></param>
        /// <returns></returns>
        public Ufr Create(Ufr ufr)
        {
            _context.Ufrs.InsertOne(ufr);
            return ufr;
        }

        /// <summary>
        /// Updating ufr details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ufrIn"></param>
        public void Update(string id, Ufr ufrIn)
        {
            _context.Ufrs.ReplaceOne(ufr => ufr.Id == id, ufrIn);
        }

        /// <summary>
        /// Deleting ufr
        /// </summary>
        /// <param name="ufrIn"></param>
        /// <returns></returns>
        public void Delete(Ufr ufrIn)
        {
            _context.Ufrs.DeleteOne(ufr => ufr.Id == ufrIn.Id);
        }

        public void Delete(string id)
        {
            var filter = Builders<Ufr>.Filter.Eq("Id", id);
            _context.Ufrs.DeleteOne(filter);
        }



        /// <summary>
        /// Search ufr
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<Ufr> Search(string search)
        {
            IQueryable<Ufr> query = from ufr in _context.Ufrs.AsQueryable()
                                    where ufr.Name.Contains(search)
                                    select ufr;

           if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(ufr => ufr.Name.Contains(search));
            }

            return query.ToList();

        }
    }
}
