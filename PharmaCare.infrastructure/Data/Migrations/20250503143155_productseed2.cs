using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class productseed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "categoryId", "description", "name", "price" },
                values: new object[] { 3, 3, "test description", "test name", 12m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "categoryId", "description", "name", "price" },
                values: new object[] { 1, 3, "test description", "test name", 12m });
        }
    }
}
