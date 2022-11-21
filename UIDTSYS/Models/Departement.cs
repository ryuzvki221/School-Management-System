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

        [BsonElement("Ufr")]
        [JsonPropertyName("Ufr")]
        public string? UrfId { get; set; }

        // [BsonElement("Filieres")]
        // [JsonPropertyName("Filieres")]
        // public List<string>? FiliereIds { get; set; }
    }
}
