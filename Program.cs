using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Repository;
using TaskSystem.Repository.Interface;
using Refit;
using TaskSystem.Integration.Refit;
using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskSystem.Services.User;


namespace TaskSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string secretKey = "43149244-8170-402b-9d18-cef25d3ee2d1";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<TaskSystemDBContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

            builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

            builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "your_business",
                    ValidAudience = "your_application",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization(); 

            app.MapControllers();

            app.Run();
        }
    }
}