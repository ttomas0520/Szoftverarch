using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SwarmWPF.ViewModel;

namespace SwarmWPF.Models.DatabaseModels {
    public class Simulation {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId GameId { get; set; }
        public int Round { get; set; }
        public BoardDTO Board { get; set; }
    }
}