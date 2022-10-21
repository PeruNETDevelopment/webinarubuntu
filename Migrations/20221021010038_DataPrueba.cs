using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webinarubuntu.Migrations
{
    public partial class DataPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { 1, 68, "Barack", "Obama", true },
                    { 2, 75, "Joe", "Biden", true },
                    { 3, 70, "Vladimir", "Putin", true }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Code", "Description", "Status", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "0001", "Xbox Series X", true, 499m },
                    { 2, "0002", "PlayStation 5", true, 630m },
                    { 3, "0003", "Nintendo Switch", true, 599m },
                    { 4, "0004", "Wii U", true, 150m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
