using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace Movimentacoes.Infra.Data.Mongo.Repository
{
    public abstract class ReadOnlyRepository<T>
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoClient _mongoClient;
        protected readonly IMongoCollection<T> _mongoCollection;

        public ReadOnlyRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mongoClient = new MongoClient(_configuration["mongoConnection:server"]);
            _mongoCollection = _mongoClient.GetDatabase(_configuration["mongoConnection:database"]).GetCollection<T>(typeof(T).Name);
        }
    }
}
