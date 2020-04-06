using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.MusicStore.Migrations
{
    public partial class IsPremiumCheckAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPremium",
                table: "Songs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPremium",
                table: "Songs");
        }
    }
}
