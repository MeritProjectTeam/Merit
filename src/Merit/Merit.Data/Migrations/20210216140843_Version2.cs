using Microsoft.EntityFrameworkCore.Migrations;

namespace Merit.Data.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMerits_Persons_PersonalInfoId",
                table: "PersonalMerits");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId",
                table: "PersonalMerits",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalMerits_PersonalInfoId",
                table: "PersonalMerits",
                newName: "IX_PersonalMerits_UserID");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserID",
                table: "CompanyMerits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserID",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    CompanyUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.CompanyUserID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserID",
                table: "Persons",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMerits_CompanyUserID",
                table: "CompanyMerits",
                column: "CompanyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyUserID",
                table: "Companies",
                column: "CompanyUserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyUsers_CompanyUserID",
                table: "Companies",
                column: "CompanyUserID",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserID",
                table: "CompanyMerits",
                column: "CompanyUserID",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMerits_Users_UserID",
                table: "PersonalMerits",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_UserID",
                table: "Persons",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyUsers_CompanyUserID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserID",
                table: "CompanyMerits");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMerits_Users_UserID",
                table: "PersonalMerits");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_UserID",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_CompanyMerits_CompanyUserID",
                table: "CompanyMerits");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyUserID",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CompanyUserID",
                table: "CompanyMerits");

            migrationBuilder.DropColumn(
                name: "CompanyUserID",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "PersonalMerits",
                newName: "PersonalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalMerits_UserID",
                table: "PersonalMerits",
                newName: "IX_PersonalMerits_PersonalInfoId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMerits_Persons_PersonalInfoId",
                table: "PersonalMerits",
                column: "PersonalInfoId",
                principalTable: "Persons",
                principalColumn: "PersonalInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
