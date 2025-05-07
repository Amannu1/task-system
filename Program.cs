using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Repository;
using TaskSystem.Repository.Interface;
using Refit;
using TaskSystem.Integration.Refit;
using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration;

namespace TaskSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<TaskSystemDBContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

            builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.MapControllers();
            app.Run();
        }
    }
}