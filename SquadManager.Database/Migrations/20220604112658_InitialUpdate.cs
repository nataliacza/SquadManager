using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquadManager.Database.Migrations
{
    public partial class InitialUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_DogExams_DogExamId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_DogExams_DogExamId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Dogs_DogId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_MemberExams_MemberExamId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Members_MemberId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_MemberExams_MemberExamId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_MemberExamId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Exams_DogExamId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_DogId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_MemberExamId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_MemberId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_DogExamId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "MemberExamId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DogExamId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "MemberExamId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "DogExamId",
                table: "Dogs");

            migrationBuilder.AddColumn<Guid>(
                name: "ExamId",
                table: "MemberExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "MemberExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DogId",
                table: "DogExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExamId",
                table: "DogExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MemberExams_ExamId",
                table: "MemberExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberExams_MemberId",
                table: "MemberExams",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_DogExams_DogId",
                table: "DogExams",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogExams_ExamId",
                table: "DogExams",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_DogExams_Dogs_DogId",
                table: "DogExams",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DogExams_Exams_ExamId",
                table: "DogExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberExams_Exams_ExamId",
                table: "MemberExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberExams_Members_MemberId",
                table: "MemberExams",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogExams_Dogs_DogId",
                table: "DogExams");

            migrationBuilder.DropForeignKey(
                name: "FK_DogExams_Exams_ExamId",
                table: "DogExams");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberExams_Exams_ExamId",
                table: "MemberExams");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberExams_Members_MemberId",
                table: "MemberExams");

            migrationBuilder.DropIndex(
                name: "IX_MemberExams_ExamId",
                table: "MemberExams");

            migrationBuilder.DropIndex(
                name: "IX_MemberExams_MemberId",
                table: "MemberExams");

            migrationBuilder.DropIndex(
                name: "IX_DogExams_DogId",
                table: "DogExams");

            migrationBuilder.DropIndex(
                name: "IX_DogExams_ExamId",
                table: "DogExams");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "MemberExams");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "MemberExams");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "DogExams");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "DogExams");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberExamId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DogExamId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DogId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MemberExamId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DogExamId",
                table: "Dogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberExamId",
                table: "Members",
                column: "MemberExamId");

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
                name: "IX_Dogs_DogExamId",
                table: "Dogs",
                column: "DogExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_DogExams_DogExamId",
                table: "Dogs",
                column: "DogExamId",
                principalTable: "DogExams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_DogExams_DogExamId",
                table: "Exams",
                column: "DogExamId",
                principalTable: "DogExams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Dogs_DogId",
                table: "Exams",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_MemberExams_MemberExamId",
                table: "Exams",
                column: "MemberExamId",
                principalTable: "MemberExams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Members_MemberId",
                table: "Exams",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MemberExams_MemberExamId",
                table: "Members",
                column: "MemberExamId",
                principalTable: "MemberExams",
                principalColumn: "Id");
        }
    }
}
