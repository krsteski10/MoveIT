#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace MoteIT.DataAccess.Data.Migrations;
public partial class initialsetup : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Order",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Distance = table.Column<int>(type: "int", nullable: false),
                LivingArea = table.Column<int>(type: "int", nullable: false),
                BasementAtticArrea = table.Column<int>(type: "int", nullable: false),
                NumberOfCars = table.Column<int>(type: "int", nullable: false),
                Piano = table.Column<bool>(type: "bit", nullable: false),
                TotalAmount = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Order", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Order");
    }
}
