using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.WebLayer.Migrations
{
    /// <inheritdoc />
    public partial class Cat2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_Categories_CategoryId",
                table: "CategoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories2",
                table: "Categories2",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_Categories2_CategoryId",
                table: "CategoryItem",
                column: "CategoryId",
                principalTable: "Categories2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_Categories2_CategoryId",
                table: "CategoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories2",
                table: "Categories2");

            migrationBuilder.RenameTable(
                name: "Categories2",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_Categories_CategoryId",
                table: "CategoryItem",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
