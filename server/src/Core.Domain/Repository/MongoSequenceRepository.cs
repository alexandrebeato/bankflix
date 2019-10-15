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
            var sequence = _mongoCollection.Find(s => s.Nome == nomeSequence).FirstOrDefault();

            if (sequence == null)
            {
                _mongoCollection.InsertOne(new MongoSequence { Nome = nomeSequence, Valor = 1 });
                return 1;
            }

            sequence.Valor++;
            _mongoCollection.FindOneAndReplace(s => s._Id == sequence._Id, sequence);
            return sequence.Valor;
        }
    }
}
