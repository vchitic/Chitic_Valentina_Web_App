using Microsoft.EntityFrameworkCore.Migrations;

namespace Chitic_Valentina_Web_App.Migrations
{
    public partial class PlantCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Plant",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "WeatherID",
                table: "Plant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeatherType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlantCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlantCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantCategory_Plant_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plant_WeatherID",
                table: "Plant",
                column: "WeatherID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantCategory_CategoryID",
                table: "PlantCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantCategory_PlantID",
                table: "PlantCategory",
                column: "PlantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Weather_WeatherID",
                table: "Plant",
                column: "WeatherID",
                principalTable: "Weather",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Weather_WeatherID",
                table: "Plant");

            migrationBuilder.DropTable(
                name: "PlantCategory");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Plant_WeatherID",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "WeatherID",
                table: "Plant");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Plant",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
