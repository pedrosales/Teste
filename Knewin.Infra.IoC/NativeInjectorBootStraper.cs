using Microsoft.Extensions.DependencyInjection;
using Knewin.Application.Services;
using Knewin.Application.Interfaces;
using Knewin.Domain.Interfaces.Repositories;
using Knewin.Infra.Data.Repositories;
using Knewin.Application;

namespace Knewin.Infra.IoC.ContainerIOC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFronteiraService, FronteiraService>();
            

            // Infra - Data
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFronteiraRepository, FronteiraRepository>();
        }
    }
}
