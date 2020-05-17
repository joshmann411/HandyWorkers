using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HandyBusiness.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "businesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    NoOfStaffs = table.Column<int>(nullable: false),
                    Province = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AddressLine = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    Dislikes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "businessPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(nullable: true),
                    businessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businessPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_businessPhotos_businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "businessSectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(nullable: true),
                    OperatingYear = table.Column<int>(nullable: false),
                    OperatingMonth = table.Column<int>(nullable: false),
                    ChargesPerHour = table.Column<double>(nullable: false),
                    businessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businessSectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_businessSectors_businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNumber = table.Column<string>(maxLength: 13, nullable: true),
                    Firstname = table.Column<string>(maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CellNo = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(maxLength: 7, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    businessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobSeekers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IDNumber = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    profilePicture = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    SkillDescription = table.Column<string>(nullable: false),
                    BusinessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobSeekers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobSeekers_businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_businessPhotos_businessId",
                table: "businessPhotos",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_businessSectors_businessId",
                table: "businessSectors",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_businessId",
                table: "Employee",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_jobSeekers_BusinessId",
                table: "jobSeekers",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "businessPhotos");

            migrationBuilder.DropTable(
                name: "businessSectors");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "jobSeekers");

            migrationBuilder.DropTable(
                name: "businesses");
        }
    }
}
