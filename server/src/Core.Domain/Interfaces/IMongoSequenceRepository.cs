using Core.Domain.Models;

namespace Core.Domain.Interfaces
{
    public interface IMongoSequenceRepository
    {
        void Inserir(MongoSequence mongoSequence);
        long ObterProximoValor(string nomeSequence);
    }
}
