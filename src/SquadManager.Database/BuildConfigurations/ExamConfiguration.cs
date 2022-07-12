using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquadManager.Database.Enums;
using SquadManager.Database.Models;


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

        builder.HasOne(x => x.Dog)
            .WithMany(x => x.Exams)
            .IsRequired(true);

        builder.HasOne(x => x.Member)
            .WithMany(x => x.Exams)
            .IsRequired(true);
    }
}
