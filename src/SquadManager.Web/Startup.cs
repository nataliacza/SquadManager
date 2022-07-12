using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Services.Configurations;
using SquadManager.Services.Middleware;
using SquadManager.Web.Configurations;


namespace SquadManager.Web;

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
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

        services.AddAutomapper();
        services.AddCoreServices();

        services.AddSwaggerGen();

        services.AddHttpContextAccessor();

        // NOTE: There is an issue with pipeline: in order to add-migration, Fluent Validation needs to be commented...
        services.AddControllers()
            .AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                opt.AutomaticValidationEnabled = true;
            });

        services.AddScoped<ErrorHandlingMiddleware>();

        services.AddRazorPages();
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

        app.UseMiddleware<ErrorHandlingMiddleware>();
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
