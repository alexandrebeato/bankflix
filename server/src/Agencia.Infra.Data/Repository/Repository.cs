using Core.Domain.Interfaces;
using Core.Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Agencia.Infra.Data.Mongo.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity<T>
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoClient _mongoClient;
        protected readonly IMongoCollection<T> _mongoCollection;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["mongoConnection:server"]);
            _mongoCollection = _mongoClient.GetDatabase(_configuration["mongoConnection:database"]).GetCollection<T>(typeof(T).Name);
        }

        public void Inserir(T entidade)
        {
            _mongoCollection.InsertOne(entidade);
        }

        public void Atualizar(T entidade)
        {
            _mongoCollection.FindOneAndReplace(p => p.Id == entidade.Id, entidade);
        }

        public void Excluir(Guid id)
        {
            _mongoCollection.FindOneAndDelete(p => p.Id == id);
        }

        public T ObterPorId(Guid id)
        {
            return _mongoCollection.Find(p => p.Id == id).FirstOrDefault();
        }

        public List<T> ObterTodos()
        {
            return _mongoCollection.Find(e => true).ToList();
        }

        public List<T> Buscar(Expression<Func<T, bool>> predicate)
        {
            return _mongoCollection.Find(predicate).ToList();
        }
    }
}
