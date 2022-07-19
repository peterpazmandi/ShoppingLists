using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddManyToManyToAppUserAndShoppingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserShoppingList",
                columns: table => new
                {
                    MembersId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShoppingListsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserShoppingList", x => new { x.MembersId, x.ShoppingListsId });
                    table.ForeignKey(
                        name: "FK_AppUserShoppingList_AspNetUsers_MembersId",
                        column: x => x.MembersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserShoppingList_ShoppingLists_ShoppingListsId",
                        column: x => x.ShoppingListsId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserShoppingList_ShoppingListsId",
                table: "AppUserShoppingList",
                column: "ShoppingListsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserShoppingList");
        }
    }
}
