using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class productseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "categoryId",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "categoryId",
                value: 1);
        }
    }
}
