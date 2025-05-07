using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Repository;
using TaskSystem.Repository.Interface;

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

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.MapControllers();
            app.Run();
        }
    }
}