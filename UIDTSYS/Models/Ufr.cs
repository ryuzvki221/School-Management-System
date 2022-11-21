﻿using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UIDTSYS.Models
{
    public class Ufr
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [BsonElement]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Departements")]
        [JsonPropertyName("Departements")]
        public List<string>? DepartementIds { get; set; }
    }
}
