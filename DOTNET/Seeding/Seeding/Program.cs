
using Microsoft.EntityFrameworkCore;
using Seeding.Models;

namespace Seeding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CountryStateCityContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("CountryState")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            app.UseHttpsRedirection();
      

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
