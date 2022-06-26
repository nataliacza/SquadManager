using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SquadManager.Database;
using SquadManager.Services.Configuration;
using SquadManager.Web.Configuration;
using System.Reflection;
using System.Text;

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
        // Project services
        services.AddCoreServices();

        // Db setup
        var defaultConnectionString = _configuration.GetConnectionString("DefaultConnection");
        var identityConnectionString = _configuration.GetConnectionString("IdentityDbConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(defaultConnectionString.ToString()));

        services.AddDbContext<IdentityDbContext>(options =>
                    options.UseSqlServer(identityConnectionString.ToString()));

        // Adding Identity and Authentication
        services.Configure<JwtConfiguration>(
            options => _configuration.GetSection("Jwt").Bind(options));

        services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = false;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };

            });

        // Other
        services.AddAutomapper();
        services.AddSwaggerGen();
        services.AddMvc();
        services.AddHttpContextAccessor();

        services
            .AddControllers()
            .AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

        services.AddRazorPages();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "squad-manager/api/{documentname}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/squad-manager/api/v1/swagger.json", "Squad Manager API V1");
                c.RoutePrefix = "squad-manager/api";
            });
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

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

        app.UseHttpsRedirection();

    }
}
