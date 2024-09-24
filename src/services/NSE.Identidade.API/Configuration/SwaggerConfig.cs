using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace NSE.Identidade.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NerdStore Entreprise Identity api",
                    Description = "Esta APi faz parte do curso ASP.net core entreprise aplication.",
                    Contact = new OpenApiContact() { Name = "Douglas dos santos", Email = "douglas@teste.com.br.io" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licesnses/MIT") }
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            });

            return app;
        }

    }
    
}
