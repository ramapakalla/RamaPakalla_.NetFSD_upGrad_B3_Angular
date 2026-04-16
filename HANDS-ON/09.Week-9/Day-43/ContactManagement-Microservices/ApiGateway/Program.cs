using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

namespace ApiGateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load Ocelot config
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

            // JWT Authentication
            var key = Encoding.UTF8.GetBytes("THIS_IS_IMPORTANT_KEY_ASKJFALKDJF57454897454");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "YourIssuer",
                    ValidAudience = "YourAudience",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddOcelot();

            var app = builder.Build();

            app.UseAuthentication();  
            app.UseAuthorization();

            await app.UseOcelot();

            app.Run();
        }
    }
}