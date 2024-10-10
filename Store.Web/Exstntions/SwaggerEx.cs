using Microsoft.OpenApi.Models;

namespace Store.Web.Exstntions
{
    public static class SwaggerEx
    {
        public static IServiceCollection AddSwagerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce", Version = "v1" });

                var SecurtySchem = new OpenApiSecurityScheme
                {
                    Description = "Jwt Token",
                    Name = "Authoriztion",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Id = "bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityDefinition("bearer", SecurtySchem);

                var x = new OpenApiSecurityRequirement
                {
                    {SecurtySchem,new[] {"bearer"} }
                };
                options.AddSecurityRequirement(x);
            }
            );
            return services;
        }
    }
}
