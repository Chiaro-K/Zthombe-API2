using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zthombe_API.Migrations
{
    /// <inheritdoc />
    public partial class addImageThumbnaileUrlcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnaileUrl",
                table: "Posts",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageThumbnaileUrl",
                table: "Posts");
        }
    }
}
