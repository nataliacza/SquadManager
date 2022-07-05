using Microsoft.EntityFrameworkCore;
using SquadManager.Db.Models;
using System.Reflection;

namespace SquadManager.Db;

public class SquadManagerContext : DbContext
{
    public SquadManagerContext(DbContextOptions<SquadManagerContext> contextOptions)
        : base(contextOptions)
    { }

    public DbSet<Member> Members { get; set; } = null!;
    public DbSet<Dog> Dogs { get; set; } = null!;
    public DbSet<Exam> Exams { get; set; } = null!;
    public DbSet<MemberProperty> MemberProperties { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
