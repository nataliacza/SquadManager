using SquadManager.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquadManager.Database.Enums;

namespace SquadManager.Database.BuildConfiguration;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        builder.Property(x => x.ExamType)
            .HasDefaultValue(ExamType.Brak)
            .IsRequired(true);

        builder.Property(x => x.ExamDate)
            .IsRequired(true);

        builder.Property(x => x.ExamExpiration)
            .IsRequired(true);
    }
}
