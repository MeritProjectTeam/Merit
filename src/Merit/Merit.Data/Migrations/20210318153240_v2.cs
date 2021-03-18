using Microsoft.EntityFrameworkCore.Migrations;

namespace Merit.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisibleMerit_CompanyAdvertisements_CompanyAdvertisementId",
                table: "VisibleMerit");

            migrationBuilder.DropForeignKey(
                name: "FK_VisibleMerit_CompanyMerits_CompanyMeritId",
                table: "VisibleMerit");

            migrationBuilder.DropForeignKey(
                name: "FK_VisibleWant_CompanyAdvertisements_CompanyAdvertisementId",
                table: "VisibleWant");

            migrationBuilder.DropForeignKey(
                name: "FK_VisibleWant_CompanyWants_CompanyWantsId",
                table: "VisibleWant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisibleWant",
                table: "VisibleWant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisibleMerit",
                table: "VisibleMerit");

            migrationBuilder.RenameTable(
                name: "VisibleWant",
                newName: "VisibleWants");

            migrationBuilder.RenameTable(
                name: "VisibleMerit",
                newName: "VisibleMerits");

            migrationBuilder.RenameIndex(
                name: "IX_VisibleWant_CompanyWantsId",
                table: "VisibleWants",
                newName: "IX_VisibleWants_CompanyWantsId");

            migrationBuilder.RenameIndex(
                name: "IX_VisibleMerit_CompanyMeritId",
                table: "VisibleMerits",
                newName: "IX_VisibleMerits_CompanyMeritId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisibleWants",
                table: "VisibleWants",
                columns: new[] { "CompanyAdvertisementId", "CompanyWantsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisibleMerits",
                table: "VisibleMerits",
                columns: new[] { "CompanyAdvertisementId", "CompanyMeritId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleMerits_CompanyAdvertisements_CompanyAdvertisementId",
                table: "VisibleMerits",
                column: "CompanyAdvertisementId",
                principalTable: "CompanyAdvertisements",
                principalColumn: "CompanyAdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleMerits_CompanyMerits_CompanyMeritId",
                table: "VisibleMerits",
                column: "CompanyMeritId",
                principalTable: "CompanyMerits",
                principalColumn: "CompanyMeritId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleWants_CompanyAdvertisements_CompanyAdvertisementId",
                table: "VisibleWants",
                column: "CompanyAdvertisementId",
                principalTable: "CompanyAdvertisements",
                principalColumn: "CompanyAdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleWants_CompanyWants_CompanyWantsId",
                table: "VisibleWants",
                column: "CompanyWantsId",
                principalTable: "CompanyWants",
                principalColumn: "CompanyWantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisibleMerits_CompanyAdvertisements_CompanyAdvertisementId",
                table: "VisibleMerits");

            migrationBuilder.DropForeignKey(
                name: "FK_VisibleMerits_CompanyMerits_CompanyMeritId",
                table: "VisibleMerits");

            migrationBuilder.DropForeignKey(
                name: "FK_VisibleWants_CompanyAdvertisements_CompanyAdvertisementId",
                table: "VisibleWants");

            migrationBuilder.DropForeignKey(
                name: "FK_VisibleWants_CompanyWants_CompanyWantsId",
                table: "VisibleWants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisibleWants",
                table: "VisibleWants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisibleMerits",
                table: "VisibleMerits");

            migrationBuilder.RenameTable(
                name: "VisibleWants",
                newName: "VisibleWant");

            migrationBuilder.RenameTable(
                name: "VisibleMerits",
                newName: "VisibleMerit");

            migrationBuilder.RenameIndex(
                name: "IX_VisibleWants_CompanyWantsId",
                table: "VisibleWant",
                newName: "IX_VisibleWant_CompanyWantsId");

            migrationBuilder.RenameIndex(
                name: "IX_VisibleMerits_CompanyMeritId",
                table: "VisibleMerit",
                newName: "IX_VisibleMerit_CompanyMeritId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisibleWant",
                table: "VisibleWant",
                columns: new[] { "CompanyAdvertisementId", "CompanyWantsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisibleMerit",
                table: "VisibleMerit",
                columns: new[] { "CompanyAdvertisementId", "CompanyMeritId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleMerit_CompanyAdvertisements_CompanyAdvertisementId",
                table: "VisibleMerit",
                column: "CompanyAdvertisementId",
                principalTable: "CompanyAdvertisements",
                principalColumn: "CompanyAdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleMerit_CompanyMerits_CompanyMeritId",
                table: "VisibleMerit",
                column: "CompanyMeritId",
                principalTable: "CompanyMerits",
                principalColumn: "CompanyMeritId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleWant_CompanyAdvertisements_CompanyAdvertisementId",
                table: "VisibleWant",
                column: "CompanyAdvertisementId",
                principalTable: "CompanyAdvertisements",
                principalColumn: "CompanyAdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleWant_CompanyWants_CompanyWantsId",
                table: "VisibleWant",
                column: "CompanyWantsId",
                principalTable: "CompanyWants",
                principalColumn: "CompanyWantsId");
        }
    }
}
