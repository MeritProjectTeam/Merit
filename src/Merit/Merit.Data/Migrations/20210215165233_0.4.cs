using Microsoft.EntityFrameworkCore.Migrations;

namespace Merit.Data.Migrations
{
    public partial class _04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CompanyMerits_CompanyId",
                table: "CompanyMerits",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMerits_Companies_CompanyId",
                table: "CompanyMerits",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMerits_Companies_CompanyId",
                table: "CompanyMerits");

            migrationBuilder.DropIndex(
                name: "IX_CompanyMerits_CompanyId",
                table: "CompanyMerits");
        }
    }
}
