using Microsoft.EntityFrameworkCore.Migrations;

namespace HandyBusiness.Migrations
{
    public partial class AddEmployeeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_businessSectors_businesses_businessId",
                table: "businessSectors");

            migrationBuilder.AlterColumn<int>(
                name: "businessId",
                table: "businessSectors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                    Gender = table.Column<string>(maxLength: 7, nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Employee_businessId",
                table: "Employee",
                column: "businessId");

            migrationBuilder.AddForeignKey(
                name: "FK_businessSectors_businesses_businessId",
                table: "businessSectors",
                column: "businessId",
                principalTable: "businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_businessSectors_businesses_businessId",
                table: "businessSectors");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "businessId",
                table: "businessSectors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_businessSectors_businesses_businessId",
                table: "businessSectors",
                column: "businessId",
                principalTable: "businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
