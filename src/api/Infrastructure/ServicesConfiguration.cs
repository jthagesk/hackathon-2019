using api.Controllers.Recommendation;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.Infrastructure
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddMemoryCache()
                .AddSingleton<HostingEnvironment>()
                .AddScoped<HotelFinder>(p => new HotelFinder(configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<GetClosestHotelWhereUserHasStayed>(p => new GetClosestHotelWhereUserHasStayed(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }


    }
}
