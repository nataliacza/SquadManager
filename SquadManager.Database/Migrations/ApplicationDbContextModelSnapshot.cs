﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SquadManager.Database;

#nullable disable

namespace SquadManager.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SquadManager.Database.Models.Dog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Breeder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChipNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("SquadManager.Database.Models.DogExam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DogId");

                    b.HasIndex("ExamId");

                    b.ToTable("DogExams");
                });

            modelBuilder.Entity("SquadManager.Database.Models.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExamExpiration")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExamType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("SquadManager.Database.Models.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("SquadManager.Database.Models.MemberExam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberExams");
                });

            modelBuilder.Entity("SquadManager.Database.Models.MemberProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("BasicCourse")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("BasicCourseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("CommanderCourse")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CommanderCourseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("ExaminerCourse")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ExaminerCourseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("GuideCourse")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GuideCourseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("HeightCourse")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("HeightCourseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("HelicopterCourse")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("HelicopterCourseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("InstructorCourse")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("InstructorCourseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Kpp")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("KppDExpiration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KppDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("MedicalExamination")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("MedicalExaminationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("MedicalExaminationExpiration")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("MemberProperties");
                });

            modelBuilder.Entity("SquadManager.Database.Models.Dog", b =>
                {
                    b.HasOne("SquadManager.Database.Models.Member", "Owner")
                        .WithMany("Dogs")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("SquadManager.Database.Models.DogExam", b =>
                {
                    b.HasOne("SquadManager.Database.Models.Dog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SquadManager.Database.Models.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("SquadManager.Database.Models.MemberExam", b =>
                {
                    b.HasOne("SquadManager.Database.Models.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SquadManager.Database.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SquadManager.Database.Models.MemberProperty", b =>
                {
                    b.HasOne("SquadManager.Database.Models.Member", "Member")
                        .WithOne("Properties")
                        .HasForeignKey("SquadManager.Database.Models.MemberProperty", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SquadManager.Database.Models.Member", b =>
                {
                    b.Navigation("Dogs");

                    b.Navigation("Properties")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
