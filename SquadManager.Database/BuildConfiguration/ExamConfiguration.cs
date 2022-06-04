using SquadManager.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .IsRequired(true);

        builder.Property(x => x.ExamDate)
            .IsRequired(true);

        builder.Property(x => x.ExamExpiration)
            .IsRequired(true);
    }
}
