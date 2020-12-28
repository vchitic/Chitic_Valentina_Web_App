using Microsoft.EntityFrameworkCore.Migrations;

namespace Chitic_Valentina_Web_App.Migrations
{
    public partial class WateringTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WateringID",
                table: "Plant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Watering",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WateringPer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watering", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plant_WateringID",
                table: "Plant",
                column: "WateringID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Watering_WateringID",
                table: "Plant",
                column: "WateringID",
                principalTable: "Watering",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Watering_WateringID",
                table: "Plant");

            migrationBuilder.DropTable(
                name: "Watering");

            migrationBuilder.DropIndex(
                name: "IX_Plant_WateringID",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "WateringID",
                table: "Plant");
        }
    }
}
