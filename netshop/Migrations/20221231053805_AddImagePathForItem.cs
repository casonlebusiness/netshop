using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netshop.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathForItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Items");
        }
    }
}
