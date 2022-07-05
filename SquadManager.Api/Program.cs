using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SquadManager.Db;
using SquadManager.Services.Configuration;

namespace SquadManager.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCoreServices();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services
            .AddControllers()
            .AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

        // Add database setup
        var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultDatabaseConnection");

        builder.Services.AddDbContext<SquadManagerContext>(options =>
                    options.UseSqlServer(defaultConnectionString));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
