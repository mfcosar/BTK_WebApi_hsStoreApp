using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class startPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Location", "Price", "Type" },
                values: new object[] { 1, "Manisa/Akhisar", 4000m, "Ege bungalov" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Location", "Price", "Type" },
                values: new object[] { 2, "Ordu/Ünye", 3000m, "Karadeniz ahşap" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Location", "Price", "Type" },
                values: new object[] { 3, "Konya/Ilgın", 2000m, "İçanadolu kerpiç" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
