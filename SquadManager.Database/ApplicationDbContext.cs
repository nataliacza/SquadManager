using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database.Models;

namespace SquadManager.Database;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Member { get; set; }
    public DbSet<Dog> Dog { get; set; }
    public DbSet<Exam> Exam { get; set; }
    public DbSet<MemberProperty> MemberProperty { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Member>()
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

    }
}
