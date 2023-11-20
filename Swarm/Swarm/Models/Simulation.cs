using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models {
    public class Simulation {
        [BsonId]
        public ObjectId Id { get; set; }
        public int Round { get; set; }
        public Board Board { get; set; }
    }
}