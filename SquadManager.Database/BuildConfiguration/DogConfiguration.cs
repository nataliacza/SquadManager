using SquadManager.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquadManager.Database.Enums;

namespace SquadManager.Database.BuildConfiguration;

public class DogConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired(true);

        builder.Property(x => x.Breeder)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(x => x.Gender)
            .HasDefaultValue(DogGender.Brak)
            .IsRequired(false);

        builder.Property(x => x.DateOfBirth)
            .IsRequired(false);

        builder.Property(x => x.ChipNumber)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Dogs)
            .IsRequired(true);
    }
}
