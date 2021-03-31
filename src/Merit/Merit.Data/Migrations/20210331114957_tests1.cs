using Microsoft.EntityFrameworkCore.Migrations;

namespace Merit.Data.Migrations
{
    public partial class tests1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInfo_CompanyUsers_CompanyUserID",
                table: "CompanyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserId",
                table: "CompanyMerits");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyWants_CompanyUsers_CompanyUserId",
                table: "CompanyWants");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInfo_PersonalUsers_PersonalUserID",
                table: "PersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMerits_PersonalUsers_PersonalUserId",
                table: "PersonalMerits");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalWants_PersonalUsers_PersonalUserId",
                table: "PersonalWants");

            migrationBuilder.RenameColumn(
                name: "PersonalUserID",
                table: "PersonalInfo",
                newName: "PersonalUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalInfo_PersonalUserID",
                table: "PersonalInfo",
                newName: "IX_PersonalInfo_PersonalUserId");

            migrationBuilder.RenameColumn(
                name: "CompanyUserID",
                table: "CompanyInfo",
                newName: "CompanyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyInfo_CompanyUserID",
                table: "CompanyInfo",
                newName: "IX_CompanyInfo_CompanyUserId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalUserId",
                table: "PersonalWants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Identity",
                table: "PersonalWants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalUserId",
                table: "PersonalMerits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Identity",
                table: "PersonalMerits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyUserId",
                table: "CompanyWants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Identity",
                table: "CompanyWants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyUserId",
                table: "CompanyMerits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Identity",
                table: "CompanyMerits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInfo_CompanyUsers_CompanyUserId",
                table: "CompanyInfo",
                column: "CompanyUserId",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserId",
                table: "CompanyMerits",
                column: "CompanyUserId",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyWants_CompanyUsers_CompanyUserId",
                table: "CompanyWants",
                column: "CompanyUserId",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInfo_PersonalUsers_PersonalUserId",
                table: "PersonalInfo",
                column: "PersonalUserId",
                principalTable: "PersonalUsers",
                principalColumn: "PersonalUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMerits_PersonalUsers_PersonalUserId",
                table: "PersonalMerits",
                column: "PersonalUserId",
                principalTable: "PersonalUsers",
                principalColumn: "PersonalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalWants_PersonalUsers_PersonalUserId",
                table: "PersonalWants",
                column: "PersonalUserId",
                principalTable: "PersonalUsers",
                principalColumn: "PersonalUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInfo_CompanyUsers_CompanyUserId",
                table: "CompanyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserId",
                table: "CompanyMerits");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyWants_CompanyUsers_CompanyUserId",
                table: "CompanyWants");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInfo_PersonalUsers_PersonalUserId",
                table: "PersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMerits_PersonalUsers_PersonalUserId",
                table: "PersonalMerits");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalWants_PersonalUsers_PersonalUserId",
                table: "PersonalWants");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "PersonalWants");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "PersonalMerits");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "CompanyWants");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "CompanyMerits");

            migrationBuilder.RenameColumn(
                name: "PersonalUserId",
                table: "PersonalInfo",
                newName: "PersonalUserID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalInfo_PersonalUserId",
                table: "PersonalInfo",
                newName: "IX_PersonalInfo_PersonalUserID");

            migrationBuilder.RenameColumn(
                name: "CompanyUserId",
                table: "CompanyInfo",
                newName: "CompanyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyInfo_CompanyUserId",
                table: "CompanyInfo",
                newName: "IX_CompanyInfo_CompanyUserID");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalUserId",
                table: "PersonalWants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalUserId",
                table: "PersonalMerits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyUserId",
                table: "CompanyWants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyUserId",
                table: "CompanyMerits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInfo_CompanyUsers_CompanyUserID",
                table: "CompanyInfo",
                column: "CompanyUserID",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserId",
                table: "CompanyMerits",
                column: "CompanyUserId",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyWants_CompanyUsers_CompanyUserId",
                table: "CompanyWants",
                column: "CompanyUserId",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInfo_PersonalUsers_PersonalUserID",
                table: "PersonalInfo",
                column: "PersonalUserID",
                principalTable: "PersonalUsers",
                principalColumn: "PersonalUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMerits_PersonalUsers_PersonalUserId",
                table: "PersonalMerits",
                column: "PersonalUserId",
                principalTable: "PersonalUsers",
                principalColumn: "PersonalUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalWants_PersonalUsers_PersonalUserId",
                table: "PersonalWants",
                column: "PersonalUserId",
                principalTable: "PersonalUsers",
                principalColumn: "PersonalUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
