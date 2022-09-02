using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindMyPG.Data.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZipCode_ZipCode_zipCodeId",
                table: "ZipCode");

            migrationBuilder.DropIndex(
                name: "IX_ZipCode_zipCodeId",
                table: "ZipCode");

            migrationBuilder.DropColumn(
                name: "zipCodeId",
                table: "ZipCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "zipCodeId",
                table: "ZipCode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_zipCodeId",
                table: "ZipCode",
                column: "zipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZipCode_ZipCode_zipCodeId",
                table: "ZipCode",
                column: "zipCodeId",
                principalTable: "ZipCode",
                principalColumn: "Id");
        }
    }
}
