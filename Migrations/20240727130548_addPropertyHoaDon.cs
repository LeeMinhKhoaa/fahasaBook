using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fahasa.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyHoaDon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaHDOnline",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaHDOnline",
                table: "HoaDon");
        }
    }
}
