using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Demo.Migrations
{
    /// <inheritdoc />
    public partial class RenamedIsCancelledPropertyToIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCancelled",
                table: "Subscription",
                newName: "IsActive");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26af7842-53e0-4680-96cb-8c02a696e59f"),
                column: "HashPassword",
                value: "$2a$11$WHijd8LmNOMz6ztD79Nk3eqrPtF1wu3P.Egb1qDo1SAV0tnj98FZi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7e892c70-763f-456e-b392-cb9211e681d3"),
                column: "HashPassword",
                value: "$2a$11$Hove00D5hZTc25mXhEwWL.WRbe.cd4PYUnW2HF3N5x/H.7pF7pmA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58"),
                column: "HashPassword",
                value: "$2a$11$mBD5iLx9j0n0LKzjfwNj2u6s/w1RlC7DC/qdvHbYNASR.WrIwZkJK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Subscription",
                newName: "IsCancelled");

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
    }
}
