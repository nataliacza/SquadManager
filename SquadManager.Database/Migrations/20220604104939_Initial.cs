using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquadManager.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DogExams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogExams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberExams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberExams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_MemberExams_MemberExamId",
                        column: x => x.MemberExamId,
                        principalTable: "MemberExams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breeder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChipNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_DogExams_DogExamId",
                        column: x => x.DogExamId,
                        principalTable: "DogExams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dogs_Members_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleType = table.Column<int>(type: "int", nullable: false),
                    Kpp = table.Column<bool>(type: "bit", nullable: true),
                    KppDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KppDExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    HelicopterCourseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberProperties_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamType = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DogExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_DogExams_DogExamId",
                        column: x => x.DogExamId,
                        principalTable: "DogExams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exams_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exams_MemberExams_MemberExamId",
                        column: x => x.MemberExamId,
                        principalTable: "MemberExams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exams_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_DogExamId",
                table: "Dogs",
                column: "DogExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_OwnerId",
                table: "Dogs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_DogExamId",
                table: "Exams",
                column: "DogExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_DogId",
                table: "Exams",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_MemberExamId",
                table: "Exams",
                column: "MemberExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_MemberId",
                table: "Exams",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberProperties_MemberId",
                table: "MemberProperties",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberExamId",
                table: "Members",
                column: "MemberExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "MemberProperties");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "DogExams");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MemberExams");
        }
    }
}
