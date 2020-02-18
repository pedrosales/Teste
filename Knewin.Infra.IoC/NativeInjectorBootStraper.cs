using Microsoft.Extensions.DependencyInjection;
using Knewin.Application;
using Knewin.Application.Interfaces;
using Knewin.Domain.Interfaces.Repositories;
using Knewin.Infra.Data.Repositories;

namespace Knewin.Infra.IoC.ContainerIOC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<ICidadeService, CidadeService>();
            

            // Infra - Data
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<ICidadeRepository, CidadeRepository>();
        }
    }
}
