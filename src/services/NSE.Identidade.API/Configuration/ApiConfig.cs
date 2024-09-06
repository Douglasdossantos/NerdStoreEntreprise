using Microsoft.AspNetCore.Mvc;
namespace NSE.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            services.AddControllers();

           

            return services;
        }
    }
}
