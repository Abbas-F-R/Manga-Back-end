using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
namespace MangaA.Extensions;

public static class ApplicationSecurityExtension
{
    public static IServiceCollection AddSecurityExtension(this IServiceCollection services, IConfiguration config)
    {
        
        
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        services.AddAuthentication().AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    config.GetSection("AppSettings:Token").Value!))
            };
        });
        // services.AddSwaggerGen(options =>
        // {
        //     options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //     {
        //         Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        //         Name = "Authorization",
        //         In = ParameterLocation.Header,
        //         Type = SecuritySchemeType.ApiKey,
        //         Scheme = "Bearer"
        //     });
        //
        //
        //     options.AddSecurityRequirement(new OpenApiSecurityRequirement
        //     {
        //         {
        //             new OpenApiSecurityScheme
        //             {
        //                 Reference = new OpenApiReference
        //                 {
        //                     Type = ReferenceType.SecurityScheme,
        //                     Id = "Bearer"
        //                 }
        //             },
        //             Array.Empty<string>()
        //         }
        //     });
        // });
        //
        // services.AddAuthentication()
        //     .AddJwtBearer(options => {
        //     options.TokenValidationParameters = new TokenValidationParameters
        //     {
        //         ValidateIssuerSigningKey = true,
        //         ValidateIssuer = false,
        //         // ValidIssuer = builder.Configuration["Jwt:Issuer"], 
        //         ValidateLifetime = true,
        //         ValidateAudience = false,
        //         // ValidAudience = builder.Configuration["Jwt:Audience"],
        //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        //             config.GetSection("AppSettings:Token").Value!))
        //     };
        // });

        return services;
    }
}