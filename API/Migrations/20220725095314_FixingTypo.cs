using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class FixingTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bougth",
                table: "Items",
                newName: "Bought");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bought",
                table: "Items",
                newName: "Bougth");
        }
    }
}
