using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class photoseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "ID", "ImageName", "productId" },
                values: new object[] { 1, "test name", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
