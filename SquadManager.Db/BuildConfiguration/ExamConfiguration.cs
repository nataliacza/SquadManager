using SquadManager.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquadManager.Db.Enums;

namespace SquadManager.Db.BuildConfiguration;

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

        builder.HasOne(x => x.DogId)
            .WithMany(x => x.Exams)
            .IsRequired(true);

        builder.HasOne(x => x.MemberId)
            .WithMany(x => x.Exams)
            .IsRequired(true);
    }
}
