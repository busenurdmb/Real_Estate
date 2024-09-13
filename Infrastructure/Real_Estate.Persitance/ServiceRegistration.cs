using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Real_Estate.Application.Interfaces;
using Real_Estate.Persitance.Repository;


namespace Real_Estate.Persitance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepository<>));
            services.AddScoped(typeof(IPropertyRepository), typeof(PropertyRepository));
            services.AddScoped(typeof(IFavoriteRepository), typeof(FavoriteRepository));
        
        }
    }
}
