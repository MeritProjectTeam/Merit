using Microsoft.EntityFrameworkCore.Migrations;

namespace Merit.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMerits_CompanyInfo_CompanyInfoId",
                table: "CompanyMerits");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserId",
                table: "CompanyMerits");

            migrationBuilder.DropIndex(
                name: "IX_CompanyMerits_CompanyInfoId",
                table: "CompanyMerits");

            migrationBuilder.DropColumn(
                name: "CompanyInfoId",
                table: "CompanyMerits");

            migrationBuilder.RenameColumn(
                name: "CompanyUserID",
                table: "CompanyUsers",
                newName: "CompanyUserId");

            migrationBuilder.RenameColumn(
                name: "CompanyUserId",
                table: "CompanyMerits",
                newName: "CompanyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMerits_CompanyUserId",
                table: "CompanyMerits",
                newName: "IX_CompanyMerits_CompanyUserID");

            migrationBuilder.CreateTable(
                name: "CompanyWants",
                columns: table => new
                {
                    CompanyWantsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Want = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyWants", x => x.CompanyWantsId);
                    table.ForeignKey(
                        name: "FK_CompanyWants_CompanyUsers_CompanyUserID",
                        column: x => x.CompanyUserID,
                        principalTable: "CompanyUsers",
                        principalColumn: "CompanyUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalWants",
                columns: table => new
                {
                    PersonalWantsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Want = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalWants", x => x.PersonalWantsID);
                    table.ForeignKey(
                        name: "FK_PersonalWants_PersonalUsers_PersonalUserId",
                        column: x => x.PersonalUserId,
                        principalTable: "PersonalUsers",
                        principalColumn: "PersonalUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyWants_CompanyUserID",
                table: "CompanyWants",
                column: "CompanyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalWants_PersonalUserId",
                table: "PersonalWants",
                column: "PersonalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserID",
                table: "CompanyMerits",
                column: "CompanyUserID",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserID",
                table: "CompanyMerits");

            migrationBuilder.DropTable(
                name: "CompanyWants");

            migrationBuilder.DropTable(
                name: "PersonalWants");

            migrationBuilder.RenameColumn(
                name: "CompanyUserId",
                table: "CompanyUsers",
                newName: "CompanyUserID");

            migrationBuilder.RenameColumn(
                name: "CompanyUserID",
                table: "CompanyMerits",
                newName: "CompanyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMerits_CompanyUserID",
                table: "CompanyMerits",
                newName: "IX_CompanyMerits_CompanyUserId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyInfoId",
                table: "CompanyMerits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMerits_CompanyInfoId",
                table: "CompanyMerits",
                column: "CompanyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMerits_CompanyInfo_CompanyInfoId",
                table: "CompanyMerits",
                column: "CompanyInfoId",
                principalTable: "CompanyInfo",
                principalColumn: "CompanyInfoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserId",
                table: "CompanyMerits",
                column: "CompanyUserId",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
