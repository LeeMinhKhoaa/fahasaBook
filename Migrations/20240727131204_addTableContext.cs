using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fahasa.Migrations
{
    /// <inheritdoc />
    public partial class addTableContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHD_HoaDon_MaHD",
                table: "ChiTietHD");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHD_Saches_MaSP",
                table: "ChiTietHD");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_Users_UserName",
                table: "HoaDon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoaDon",
                table: "HoaDon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietHD",
                table: "ChiTietHD");

            migrationBuilder.RenameTable(
                name: "HoaDon",
                newName: "HoaDons");

            migrationBuilder.RenameTable(
                name: "ChiTietHD",
                newName: "chiTietHDs");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_UserName",
                table: "HoaDons",
                newName: "IX_HoaDons_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHD_MaSP",
                table: "chiTietHDs",
                newName: "IX_chiTietHDs_MaSP");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHD_MaHD",
                table: "chiTietHDs",
                newName: "IX_chiTietHDs_MaHD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoaDons",
                table: "HoaDons",
                column: "MaHD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chiTietHDs",
                table: "chiTietHDs",
                column: "MaCTHD");

            migrationBuilder.AddForeignKey(
                name: "FK_chiTietHDs_HoaDons_MaHD",
                table: "chiTietHDs",
                column: "MaHD",
                principalTable: "HoaDons",
                principalColumn: "MaHD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chiTietHDs_Saches_MaSP",
                table: "chiTietHDs",
                column: "MaSP",
                principalTable: "Saches",
                principalColumn: "MaSach",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_Users_UserName",
                table: "HoaDons",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chiTietHDs_HoaDons_MaHD",
                table: "chiTietHDs");

            migrationBuilder.DropForeignKey(
                name: "FK_chiTietHDs_Saches_MaSP",
                table: "chiTietHDs");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_Users_UserName",
                table: "HoaDons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoaDons",
                table: "HoaDons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chiTietHDs",
                table: "chiTietHDs");

            migrationBuilder.RenameTable(
                name: "HoaDons",
                newName: "HoaDon");

            migrationBuilder.RenameTable(
                name: "chiTietHDs",
                newName: "ChiTietHD");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDons_UserName",
                table: "HoaDon",
                newName: "IX_HoaDon_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_chiTietHDs_MaSP",
                table: "ChiTietHD",
                newName: "IX_ChiTietHD_MaSP");

            migrationBuilder.RenameIndex(
                name: "IX_chiTietHDs_MaHD",
                table: "ChiTietHD",
                newName: "IX_ChiTietHD_MaHD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoaDon",
                table: "HoaDon",
                column: "MaHD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietHD",
                table: "ChiTietHD",
                column: "MaCTHD");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHD_HoaDon_MaHD",
                table: "ChiTietHD",
                column: "MaHD",
                principalTable: "HoaDon",
                principalColumn: "MaHD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHD_Saches_MaSP",
                table: "ChiTietHD",
                column: "MaSP",
                principalTable: "Saches",
                principalColumn: "MaSach",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_Users_UserName",
                table: "HoaDon",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
