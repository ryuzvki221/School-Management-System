using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UIDTSYS.Models
{
    public class Filiere 
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [BsonElement]
        public string Name { get; set; } = string.Empty;

        // Relationships: Many to One
        [BsonElement("Departement")]
        [JsonPropertyName("Departement")]
        public string DepartementId { get; set; } = string.Empty;
    }
}