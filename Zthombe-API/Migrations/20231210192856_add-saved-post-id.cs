using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zthombe_API.Migrations
{
    /// <inheritdoc />
    public partial class addsavedpostid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SavedPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid());

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedPosts",
                table: "SavedPosts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedPosts",
                table: "SavedPosts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SavedPosts");
        }
    }
}
