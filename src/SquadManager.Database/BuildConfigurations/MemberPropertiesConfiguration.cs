using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquadManager.Database.Enums;
using SquadManager.Database.Models;


namespace SquadManager.Database.BuildConfiguration;

public class MemberPropertiesConfiguration : IEntityTypeConfiguration<MemberProperty>
{
    public void Configure(EntityTypeBuilder<MemberProperty> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        builder.HasOne(x => x.Member)
            .WithOne(x => x.Properties)
            .HasForeignKey<Member>(x => x.PropertyId)
            .IsRequired(true);

        builder.Property(x => x.RoleType)
            .HasDefaultValue(RoleType.Brak)
            .IsRequired(true);

        builder.Property(x => x.Kpp)
            .IsRequired(false);

        builder.Property(x => x.KppDate)
            .IsRequired(false);

        builder.Property(x => x.KppExpiration)
            .IsRequired(false);

        builder.Property(x => x.MedicalExamination)
            .IsRequired(false);

        builder.Property(x => x.MedicalExaminationDate)
            .IsRequired(false);

        builder.Property(x => x.MedicalExaminationExpiration)
            .IsRequired(false);

        builder.Property(x => x.BasicCourse)
            .IsRequired(false);

        builder.Property(x => x.BasicCourseDate)
            .IsRequired(false);

        builder.Property(x => x.GuideCourse)
            .IsRequired(false);

        builder.Property(x => x.GuideCourseDate)
            .IsRequired(false);

        builder.Property(x => x.InstructorCourse)
            .IsRequired(false);

        builder.Property(x => x.InstructorCourseDate)
            .IsRequired(false);

        builder.Property(x => x.ExaminerCourse)
            .IsRequired(false);

        builder.Property(x => x.ExaminerCourseDate)
            .IsRequired(false);

        builder.Property(x => x.CommanderCourse)
            .IsRequired(false);

        builder.Property(x => x.CommanderCourseDate)
            .IsRequired(false);

        builder.Property(x => x.HeightCourse)
            .IsRequired(false);

        builder.Property(x => x.HeightCourseDate)
            .IsRequired(false);

        builder.Property(x => x.HelicopterCourse)
            .IsRequired(false);

        builder.Property(x => x.HelicopterCourseDate)
            .IsRequired(false);
    }
}
