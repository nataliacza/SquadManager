using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquadManager.Database.Migrations
{
    public partial class Update_MemberProperty_IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Members");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Members");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
