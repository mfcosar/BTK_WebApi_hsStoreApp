using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddCategoryResourceToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a1bf44b-4d00-4018-90aa-9cc901ef01f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bfd02d4-ce32-47df-a8f9-249d2d457bc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71dba109-85b7-4c54-8199-e7135b6dc462");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42c1889b-3e9c-4f9b-bf4d-e846e1bbe41c", "141a806b-ebbb-43d7-a912-603c10efbb90", "Editor", "EDITOR" },
                    { "5b301d37-28da-46c8-9588-1a7ccc6c6069", "3d636b94-9463-4030-887b-e1241156b777", "User", "USER" },
                    { "d6c87cf6-c566-414a-86b6-4442cf761246", "ad8a7167-e7fd-4b13-856c-f6961994c385", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Müstakil" },
                    { 2, "Bahçeli" },
                    { 3, "Apartman dairesi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42c1889b-3e9c-4f9b-bf4d-e846e1bbe41c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b301d37-28da-46c8-9588-1a7ccc6c6069");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6c87cf6-c566-414a-86b6-4442cf761246");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a1bf44b-4d00-4018-90aa-9cc901ef01f6", "c3f53987-0bb5-4f90-a03f-1310732db227", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bfd02d4-ce32-47df-a8f9-249d2d457bc8", "717cb884-d454-4f56-bc79-212f4c67b926", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71dba109-85b7-4c54-8199-e7135b6dc462", "d19cf611-a499-4a6e-a00e-a42eed74a4b2", "Admin", "ADMIN" });
        }
    }
}
