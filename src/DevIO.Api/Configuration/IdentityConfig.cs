using DevIO.Api.Data;
using DevIO.Api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DevIO.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Connections

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            
            // JWT

            var appSettingsSection = configuration.GetSection(key: "AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(configureOptions: x => 
            {
                // Toda padrao de autenticação gerar um token
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                // Toda vez que for validar buscar o token
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => 
            {
                // Evita ataque main in the meadle
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    // Valida se quem está emitindo tem que ser o mesmo que o token, não apenas o nome, mas tambem a chave
                    ValidateIssuerSigningKey = true,
                    // Configura a chave ASCII para uma criptografada
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    // Valida apenas o issuer pelo nome
                    ValidateIssuer = true,
                    // A onde o token é valido
                    ValidateAudience = true,
                    // Diz quem é a audiencia e quem é o issuer
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };
            });

            return services;
        }
    }
}
