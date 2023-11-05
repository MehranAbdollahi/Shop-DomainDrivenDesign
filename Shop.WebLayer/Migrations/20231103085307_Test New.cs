using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.WebLayer.Migrations
{
    /// <inheritdoc />
    public partial class TestNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "Categories",
                newName: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
