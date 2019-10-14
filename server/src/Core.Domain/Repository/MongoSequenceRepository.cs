using Core.Domain.Interfaces;
using Core.Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Core.Domain.Repository
{
    public class MongoSequenceRepository : IMongoSequenceRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoClient _mongoClient;
        protected readonly IMongoCollection<MongoSequence> _mongoCollection;

        public MongoSequenceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["mongoConnection:server"]);
            _mongoCollection = _mongoClient.GetDatabase(_configuration["mongoConnection:database"]).GetCollection<MongoSequence>(typeof(MongoSequence).Name);
        }

        public void Inserir(MongoSequence mongoSequence)
        {
            _mongoCollection.InsertOne(mongoSequence);
        }

        public long ObterProximoValor(string nomeSequence)
        {
            var filter = Builders<MongoSequence>.Filter.Eq(a => a.Nome, nomeSequence);
            var update = Builders<MongoSequence>.Update.Inc(a => a.Valor, 1);
            var sequence = _mongoCollection.FindOneAndUpdate(filter, update);
            return sequence.Valor;
        }
    }
}
