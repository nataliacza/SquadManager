using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquadManager.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Kpp = table.Column<bool>(type: "bit", nullable: true),
                    KppDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KppExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedicalExamination = table.Column<bool>(type: "bit", nullable: true),
                    MedicalExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedicalExaminationExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BasicCourse = table.Column<bool>(type: "bit", nullable: true),
                    BasicCourseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuideCourse = table.Column<bool>(type: "bit", nullable: true),
                    GuideCourseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstructorCourse = table.Column<bool>(type: "bit", nullable: true),
                    InstructorCourseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExaminerCourse = table.Column<bool>(type: "bit", nullable: true),
                    ExaminerCourseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommanderCourse = table.Column<bool>(type: "bit", nullable: true),
                    CommanderCourseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeightCourse = table.Column<bool>(type: "bit", nullable: true),
                    HeightCourseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HelicopterCourse = table.Column<bool>(type: "bit", nullable: true),
                    HelicopterCourseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_MemberProperties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "MemberProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Breeder = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChipNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Members_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exams_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_OwnerId",
                table: "Dogs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_DogId",
                table: "Exams",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_MemberId",
                table: "Exams",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PropertyId",
                table: "Members",
                column: "PropertyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MemberProperties");
        }
    }
}
