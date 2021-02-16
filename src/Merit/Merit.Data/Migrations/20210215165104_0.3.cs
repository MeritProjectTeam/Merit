using Microsoft.EntityFrameworkCore.Migrations;

namespace Merit.Data.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalInfoID",
                table: "Persons",
                newName: "PersonalInfoId");

            migrationBuilder.RenameColumn(
                name: "PersonalMeritID",
                table: "PersonalMerits",
                newName: "PersonalMeritId");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "PersonalMerits",
                newName: "PersonalInfoId");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "CompanyMerits",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "CompanyMeritID",
                table: "CompanyMerits",
                newName: "CompanyMeritId");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Companies",
                newName: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMerits_PersonalInfoId",
                table: "PersonalMerits",
                column: "PersonalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMerits_Persons_PersonalInfoId",
                table: "PersonalMerits",
                column: "PersonalInfoId",
                principalTable: "Persons",
                principalColumn: "PersonalInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMerits_Persons_PersonalInfoId",
                table: "PersonalMerits");

            migrationBuilder.DropIndex(
                name: "IX_PersonalMerits_PersonalInfoId",
                table: "PersonalMerits");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId",
                table: "Persons",
                newName: "PersonalInfoID");

            migrationBuilder.RenameColumn(
                name: "PersonalMeritId",
                table: "PersonalMerits",
                newName: "PersonalMeritID");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId",
                table: "PersonalMerits",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CompanyMerits",
                newName: "CompanyID");

            migrationBuilder.RenameColumn(
                name: "CompanyMeritId",
                table: "CompanyMerits",
                newName: "CompanyMeritID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companies",
                newName: "CompanyID");
        }
    }
}
