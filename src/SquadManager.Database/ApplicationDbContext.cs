using Microsoft.EntityFrameworkCore;
using SquadManager.Database.Models;
using System.Reflection;

namespace SquadManager.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
        : base(contextOptions)
    { }

    public DbSet<Member> Members { get; set; } // => Set<Member>();
    public DbSet<Dog> Dogs { get; set; } // => Set<Dog>();
    public DbSet<Exam> Exams { get; set; } // => Set<Exam>();
    public DbSet<MemberProperty> MemberProperties { get; set; } // => Set<MemberProperty>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
