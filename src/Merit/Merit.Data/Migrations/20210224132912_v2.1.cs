using Microsoft.EntityFrameworkCore.Migrations;

namespace Merit.Data.Migrations
{
    public partial class v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyWants_CompanyUsers_CompanyUserID",
                table: "CompanyWants");

            migrationBuilder.RenameColumn(
                name: "CompanyUserID",
                table: "CompanyWants",
                newName: "CompanyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyWants_CompanyUserID",
                table: "CompanyWants",
                newName: "IX_CompanyWants_CompanyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyWants_CompanyUsers_CompanyUserId",
                table: "CompanyWants",
                column: "CompanyUserId",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyWants_CompanyUsers_CompanyUserId",
                table: "CompanyWants");

            migrationBuilder.RenameColumn(
                name: "CompanyUserId",
                table: "CompanyWants",
                newName: "CompanyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyWants_CompanyUserId",
                table: "CompanyWants",
                newName: "IX_CompanyWants_CompanyUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyWants_CompanyUsers_CompanyUserID",
                table: "CompanyWants",
                column: "CompanyUserID",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
