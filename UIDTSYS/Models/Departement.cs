using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UIDTSYS.Models
{
    public class Departement
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [BsonElement]
        public string Name { get; set; } = string.Empty;

        // Relationships: Many to One
        [BsonElement("Ufr")]
        [JsonPropertyName("Ufr")]
        public string UfrId { get; set; } = string.Empty;
        // Relationships: One to Many
        [BsonElement("Filieres")]
        [JsonPropertyName("Filieres")]
        public List<Filiere>? Filieres { get; set; }
    }
}