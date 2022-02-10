using Microsoft.Extensions.DependencyInjection;
using Infra.Repositorios;
using Dominio.Repositorios;

namespace IoC
{
    public static class ResolvedorDeDependencias
    {
        public static IServiceCollection AdicionarDependencias(this IServiceCollection services)
        {
            AdicionarRepositorios(services);

            return services;
        }

        private static IServiceCollection AdicionarRepositorios(IServiceCollection services)
        {
            services.AddScoped<ICepRepositorio, CepRepositorio>();

            return services;
        }
    }
}
