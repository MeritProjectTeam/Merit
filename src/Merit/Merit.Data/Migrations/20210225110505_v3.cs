using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merit.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserID",
                table: "CompanyMerits");

            migrationBuilder.RenameColumn(
                name: "CompanyUserID",
                table: "CompanyMerits",
                newName: "CompanyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMerits_CompanyUserID",
                table: "CompanyMerits",
                newName: "IX_CompanyMerits_CompanyUserId");

            migrationBuilder.CreateTable(
                name: "CompanyImages",
                columns: table => new
                {
                    CompanyImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyImages", x => x.CompanyImageId);
                    table.ForeignKey(
                        name: "FK_CompanyImages_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "CompanyUsers",
                        principalColumn: "CompanyUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalImages",
                columns: table => new
                {
                    PersonalImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalImages", x => x.PersonalImageId);
                    table.ForeignKey(
                        name: "FK_PersonalImages_PersonalUsers_PersonalUserId",
                        column: x => x.PersonalUserId,
                        principalTable: "PersonalUsers",
                        principalColumn: "PersonalUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyImages_CompanyUserId",
                table: "CompanyImages",
                column: "CompanyUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalImages_PersonalUserId",
                table: "PersonalImages",
                column: "PersonalUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserId",
                table: "CompanyMerits",
                column: "CompanyUserId",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserId",
                table: "CompanyMerits");

            migrationBuilder.DropTable(
                name: "CompanyImages");

            migrationBuilder.DropTable(
                name: "PersonalImages");

            migrationBuilder.RenameColumn(
                name: "CompanyUserId",
                table: "CompanyMerits",
                newName: "CompanyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMerits_CompanyUserId",
                table: "CompanyMerits",
                newName: "IX_CompanyMerits_CompanyUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMerits_CompanyUsers_CompanyUserID",
                table: "CompanyMerits",
                column: "CompanyUserID",
                principalTable: "CompanyUsers",
                principalColumn: "CompanyUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
