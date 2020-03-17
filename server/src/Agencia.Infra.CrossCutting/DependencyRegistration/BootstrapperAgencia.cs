using Agencia.Domain.Agencia.Repository;
using Agencia.Infra.Data.Mongo.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Agencia.Infra.CrossCutting.DependencyRegistration
{
    public static class BootstrapperAgencia
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<IAgenciaRepository, AgenciaRepository>();
        }
    }
}
