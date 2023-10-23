using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.WebLayer.Migrations
{
    /// <inheritdoc />
    public partial class ParentIDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalCategoryItems",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCategoryItems",
                table: "Categories");
        }
    }
}
