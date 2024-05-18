using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exam1And2_Web2_IUSR.Models
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Id", "Email", "Father", "Fname", "Lname", "PostalCode", "phoneNumber" },
                values: new object[,]
                {
                    { 1, "Customer 1", "Customer 1", "Customer 1", "Customer 1", 1234, "123-123" },
                    { 2, "Customer 2", "Customer 2", "Customer 2", "Customer 2", 2345, "234-234" },
                    { 3, "Customer 3", "Customer 3", "Customer 3", "Customer 3", 3456, "345-345" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}