using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "description", "name" },
                values: new object[] { 1, "Test description", "test name" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "categoryId", "description", "name", "price" },
                values: new object[] { 1, 1, "test description", "test name", 12m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
