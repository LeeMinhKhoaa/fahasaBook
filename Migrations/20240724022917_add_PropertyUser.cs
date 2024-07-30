using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fahasa.Migrations
{
    /// <inheritdoc />
    public partial class add_PropertyUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RandomKey",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RandomKey",
                table: "Users");
        }
    }
}
