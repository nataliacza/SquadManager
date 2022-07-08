using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SquadManager.Api.Configuration;
using SquadManager.Db;
using SquadManager.Services.Configuration;

namespace SquadManager.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Database setup
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<SquadManagerContext>(options =>
                    options.UseSqlServer(connectionString));

        // Project services
        services.AddAutomapper();
        services.AddCoreServices();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddControllers()
            //.AddFluentValidation(x =>
            //{
            //    x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            //})
            ;

        services.AddHttpContextAccessor();
        services.AddRazorPages();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Auth must be after UserRouting and before UseEndpoints
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
