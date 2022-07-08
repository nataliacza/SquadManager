using Microsoft.EntityFrameworkCore;
using SquadManager.Db.Enums;
using SquadManager.Db.Models;

namespace SquadManager.Db;

public class SquadManagerContext : DbContext
{
    public SquadManagerContext(DbContextOptions<SquadManagerContext> contextOptions)
        : base(contextOptions)
    { }

    public DbSet<Member> Members => Set<Member>();
    public DbSet<Dog> Dogs => Set<Dog>();
    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<MemberProperty> MemberProperties => Set<MemberProperty>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Member>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Member>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        modelBuilder.Entity<Member>()
            .Property(x => x.FirstName)
            .HasMaxLength(30)
            .IsRequired(true);

        modelBuilder.Entity<Member>()
            .Property(x => x.LastName)
            .HasMaxLength(30)
            .IsRequired(true);

        modelBuilder.Entity<Member>()
            .Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired(true);

        modelBuilder.Entity<Member>()
            .Property(x => x.Mobile)
            .HasMaxLength(10)
            .IsRequired(true);

        modelBuilder.Entity<Member>()
            .HasOne(x => x.Properties)
            .WithOne(x => x.Member)
            .HasForeignKey<Member>(x => x.Id)
            .IsRequired(true);

        modelBuilder.Entity<Member>()
            .HasMany(x => x.Dogs)
            .WithOne(x => x.Owner)
            .IsRequired(false);



        modelBuilder.Entity<Dog>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Dog>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        modelBuilder.Entity<Dog>()
            .Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired(true);

        modelBuilder.Entity<Dog>()
            .Property(x => x.Breeder)
            .HasMaxLength(50)
            .IsRequired(false);

        modelBuilder.Entity<Dog>()
            .Property(x => x.Gender)
            .HasDefaultValue(DogGender.Brak)
            .IsRequired(false);

        modelBuilder.Entity<Dog>()
            .Property(x => x.DateOfBirth)
            .IsRequired(false);

        modelBuilder.Entity<Dog>()
            .Property(x => x.ChipNumber)
            .HasMaxLength(50)
            .IsRequired(false);

        modelBuilder.Entity<Dog>()
            .HasOne(x => x.Owner)
            .WithMany(x => x.Dogs)
            .IsRequired(true);



        modelBuilder.Entity<Exam>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Exam>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        modelBuilder.Entity<Exam>()
            .Property(x => x.ExamType)
            .HasDefaultValue(ExamType.Brak)
            .IsRequired(true);

        modelBuilder.Entity<Exam>()
            .Property(x => x.ExamDate)
            .IsRequired(true);

        modelBuilder.Entity<Exam>()
            .Property(x => x.ExamExpiration)
            .IsRequired(true);

        modelBuilder.Entity<Exam>()
            .HasOne(x => x.DogId)
            .WithMany(x => x.Exams)
            .IsRequired(true);

        modelBuilder.Entity<Exam>()
            .HasOne(x => x.MemberId)
            .WithMany(x => x.Exams)
            .IsRequired(true);



        modelBuilder.Entity<MemberProperty>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.RoleType)
            .HasDefaultValue(RoleType.Brak)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.Kpp)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.KppDate)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.KppExpiration)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.MedicalExamination)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.MedicalExaminationDate)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.MedicalExaminationExpiration)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.BasicCourse)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.BasicCourseDate)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.GuideCourse)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.GuideCourseDate)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.InstructorCourse)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.InstructorCourseDate)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.ExaminerCourse)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.ExaminerCourseDate)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.CommanderCourse)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.CommanderCourseDate)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.HeightCourse)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.HeightCourseDate)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.HelicopterCourse)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .Property(x => x.HelicopterCourseDate)
            .IsRequired(false);

        modelBuilder.Entity<MemberProperty>()
            .HasOne(x => x.Member)
            .WithOne(x => x.Properties)
            .HasForeignKey<Member>(x => x.PropertyId)
            .IsRequired(true);
    }
}
