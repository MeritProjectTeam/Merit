using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merit.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    CompanyUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.CompanyUserId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalUsers",
                columns: table => new
                {
                    PersonalUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalUsers", x => x.PersonalUserId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAdvertisements",
                columns: table => new
                {
                    CompanyAdvertisementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormOfEmployment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAdvertisements", x => x.CompanyAdvertisementId);
                    table.ForeignKey(
                        name: "FK_CompanyAdvertisements_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "CompanyUsers",
                        principalColumn: "CompanyUserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "CompanyInfo",
                columns: table => new
                {
                    CompanyInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.CompanyInfoId);
                    table.ForeignKey(
                        name: "FK_CompanyInfo_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "CompanyUsers",
                        principalColumn: "CompanyUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMerits",
                columns: table => new
                {
                    CompanyMeritId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMerits", x => x.CompanyMeritId);
                    table.ForeignKey(
                        name: "FK_CompanyMerits_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "CompanyUsers",
                        principalColumn: "CompanyUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyWants",
                columns: table => new
                {
                    CompanyWantsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Want = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyWants", x => x.CompanyWantsId);
                    table.ForeignKey(
                        name: "FK_CompanyWants_CompanyUsers_CompanyUserId",
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

            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                columns: table => new
                {
                    PersonalInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.PersonalInfoId);
                    table.ForeignKey(
                        name: "FK_PersonalInfo_PersonalUsers_PersonalUserId",
                        column: x => x.PersonalUserId,
                        principalTable: "PersonalUsers",
                        principalColumn: "PersonalUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalMerits",
                columns: table => new
                {
                    PersonalMeritId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalMerits", x => x.PersonalMeritId);
                    table.ForeignKey(
                        name: "FK_PersonalMerits_PersonalUsers_PersonalUserId",
                        column: x => x.PersonalUserId,
                        principalTable: "PersonalUsers",
                        principalColumn: "PersonalUserId",
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

            migrationBuilder.CreateTable(
                name: "VisibleMerits",
                columns: table => new
                {
                    CompanyAdvertisementId = table.Column<int>(type: "int", nullable: false),
                    CompanyMeritId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisibleMerits", x => new { x.CompanyAdvertisementId, x.CompanyMeritId });
                    table.ForeignKey(
                        name: "FK_VisibleMerits_CompanyAdvertisements_CompanyAdvertisementId",
                        column: x => x.CompanyAdvertisementId,
                        principalTable: "CompanyAdvertisements",
                        principalColumn: "CompanyAdvertisementId");
                    table.ForeignKey(
                        name: "FK_VisibleMerits_CompanyMerits_CompanyMeritId",
                        column: x => x.CompanyMeritId,
                        principalTable: "CompanyMerits",
                        principalColumn: "CompanyMeritId");
                });

            migrationBuilder.CreateTable(
                name: "VisibleWants",
                columns: table => new
                {
                    CompanyAdvertisementId = table.Column<int>(type: "int", nullable: false),
                    CompanyWantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisibleWants", x => new { x.CompanyAdvertisementId, x.CompanyWantsId });
                    table.ForeignKey(
                        name: "FK_VisibleWants_CompanyAdvertisements_CompanyAdvertisementId",
                        column: x => x.CompanyAdvertisementId,
                        principalTable: "CompanyAdvertisements",
                        principalColumn: "CompanyAdvertisementId");
                    table.ForeignKey(
                        name: "FK_VisibleWants_CompanyWants_CompanyWantsId",
                        column: x => x.CompanyWantsId,
                        principalTable: "CompanyWants",
                        principalColumn: "CompanyWantsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAdvertisements_CompanyUserId",
                table: "CompanyAdvertisements",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyImages_CompanyUserId",
                table: "CompanyImages",
                column: "CompanyUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInfo_CompanyUserId",
                table: "CompanyInfo",
                column: "CompanyUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMerits_CompanyUserId",
                table: "CompanyMerits",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyWants_CompanyUserId",
                table: "CompanyWants",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalImages_PersonalUserId",
                table: "PersonalImages",
                column: "PersonalUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfo_PersonalUserId",
                table: "PersonalInfo",
                column: "PersonalUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMerits_PersonalUserId",
                table: "PersonalMerits",
                column: "PersonalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalWants_PersonalUserId",
                table: "PersonalWants",
                column: "PersonalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VisibleMerits_CompanyMeritId",
                table: "VisibleMerits",
                column: "CompanyMeritId");

            migrationBuilder.CreateIndex(
                name: "IX_VisibleWants_CompanyWantsId",
                table: "VisibleWants",
                column: "CompanyWantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyImages");

            migrationBuilder.DropTable(
                name: "CompanyInfo");

            migrationBuilder.DropTable(
                name: "PersonalImages");

            migrationBuilder.DropTable(
                name: "PersonalInfo");

            migrationBuilder.DropTable(
                name: "PersonalMerits");

            migrationBuilder.DropTable(
                name: "PersonalWants");

            migrationBuilder.DropTable(
                name: "VisibleMerits");

            migrationBuilder.DropTable(
                name: "VisibleWants");

            migrationBuilder.DropTable(
                name: "PersonalUsers");

            migrationBuilder.DropTable(
                name: "CompanyMerits");

            migrationBuilder.DropTable(
                name: "CompanyAdvertisements");

            migrationBuilder.DropTable(
                name: "CompanyWants");

            migrationBuilder.DropTable(
                name: "CompanyUsers");
        }
    }
}
