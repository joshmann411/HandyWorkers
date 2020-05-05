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
                    businessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businessSectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_businessSectors_businesses_businessId",
                        column: x => x.businessId,
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "businessPhotos");

            migrationBuilder.DropTable(
                name: "businessSectors");

            migrationBuilder.DropTable(
                name: "businesses");
        }
    }
}
