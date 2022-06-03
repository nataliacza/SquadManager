using Microsoft.EntityFrameworkCore;
using SquadManager.Database.Models;

namespace SquadManager.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
    {
    }

    public DbSet<Member> Members { get; set; } = null!;
    public DbSet<Dog> Dogs { get; set; } = null!;
    public DbSet<Exam> Exams { get; set; } = null!;
    public DbSet<MemberProperty> MemberProperties { get; set; } = null!;
}
