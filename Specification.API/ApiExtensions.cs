using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Specification.Infrastructure;

namespace Specification.API
{
    public static class ApiExtensions
    {
        public static void AddApiAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie()
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme,
                    opt =>
                    {
                        opt.TokenValidationParameters = new()
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(jwtOptions!.SecretKey)
                            )
                        };
                        opt.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                context.Token = context.Request.Cookies["vsm_token_cookies"];
                                return Task.CompletedTask;
                            }
                        };
                    }
                );

            services.AddAuthorization();

            //options =>
            //{
            //    //options.AddPolicy("UserPolicy", policy =>
            //    //{
            //    //    policy.RequireClaim("role", "[User]");
            //    //});
            //    //options.AddPolicy("PolicyEngineerCD", policy =>
            //    //{
            //    //    policy.RequireClaim("role", "[User]", "[EngineerCD,User]");
            //    //});
            //}
        }
    }
}
