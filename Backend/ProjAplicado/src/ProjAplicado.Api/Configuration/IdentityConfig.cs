using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjAplicado.Api.Data;
using ProjAplicado.Api.Extensions;
using System.Text;

namespace ProjAplicado.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<IdentityErroMensagensPortugues>()
                .AddDefaultTokenProviders();

            //JWT

            var appSettingsSection = configuration.GetSection("AppSettingsJWT");
            services.Configure<AppSettingsJWT>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettingsJWT>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = appSettings.ValidoEm,
                        
                    };
                });


            return services;
        }
    }
}
