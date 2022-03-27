using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car.Demo.Migrations
{
    /// <inheritdoc />
    public partial class Seedingcompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7ac01ada-b23d-4fa8-8b45-a5f6ef0847c8"), "BMW" },
                    { new Guid("a9ac07e2-2402-480d-9b3e-fcd0da8d2f64"), "Mercedes-benz" },
                    { new Guid("bc0a09f3-0fdd-4a8b-a419-86235a775760"), "Audi" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26af7842-53e0-4680-96cb-8c02a696e59f"),
                column: "HashPassword",
                value: "$2a$11$61eoJwZ/Mi19s3LUA1ZGNeCbjMMn2W2oKIoVDesEcw.FXqY8BF.1u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7e892c70-763f-456e-b392-cb9211e681d3"),
                column: "HashPassword",
                value: "$2a$11$G9LgGbBizj23B5XLqnQvKe5EjYMZ7cOxlHmKEOiBzAwaA5oeBMnA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58"),
                column: "HashPassword",
                value: "$2a$11$UveoDJT8ZbnwEE.B6dstBOciWVrCLNxhYixmX.FYTr6PaE37Fje0S");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("7ac01ada-b23d-4fa8-8b45-a5f6ef0847c8"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a9ac07e2-2402-480d-9b3e-fcd0da8d2f64"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bc0a09f3-0fdd-4a8b-a419-86235a775760"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26af7842-53e0-4680-96cb-8c02a696e59f"),
                column: "HashPassword",
                value: "$2a$11$nHm1.sI6peZi3BEx98Vkxuqko.QRPf49wz9niwItsjpMUeuqmmwW2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7e892c70-763f-456e-b392-cb9211e681d3"),
                column: "HashPassword",
                value: "$2a$11$SGFsuUzN2i5SklK3g9qhjeim9BSo9IE1zaLKgctj01gw5iYEefwl.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58"),
                column: "HashPassword",
                value: "$2a$11$ODAh77Yqny0FgseEfM96KOUKcgJwJmFNh0bBDdEQBOWV9FfRcH/mm");
        }
    }
}
