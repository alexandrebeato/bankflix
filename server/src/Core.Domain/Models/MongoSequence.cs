using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Domain.Models
{
    public class MongoSequence
    {
        [BsonId]
        public ObjectId _Id { get; set; }

        public string Nome { get; set; }

        public long Valor { get; set; }
    }
}
