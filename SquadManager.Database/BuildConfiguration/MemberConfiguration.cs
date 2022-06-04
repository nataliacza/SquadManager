using SquadManager.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SquadManager.Database.BuildConfiguration;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        builder.Property(x => x.FirstName)
            .HasMaxLength(25)
            .IsRequired(true);

        builder.Property(x => x.LastName)
            .HasMaxLength(30)
            .IsRequired(true);

        builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired(true);

        builder.Property(x => x.Mobile)
            .HasMaxLength(10)
            .IsRequired(true);

        builder.HasOne(x => x.Properties)
            .WithOne(x => x.Member)
            .HasForeignKey<Member>(x => x.Id)
            .IsRequired(true);

        builder.HasMany(x => x.Dogs)
            .WithOne(x => x.Owner)
            .IsRequired(false);
    }
}
