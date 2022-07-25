using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddBoughtPropertyToItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Bougth",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bougth",
                table: "Items");
        }
    }
}
