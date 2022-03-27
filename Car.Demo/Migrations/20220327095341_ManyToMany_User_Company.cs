using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Demo.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany_User_Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => new { x.UserId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_Subscription_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscription_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_CompanyId",
                table: "Subscription",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26af7842-53e0-4680-96cb-8c02a696e59f"),
                column: "HashPassword",
                value: "$2a$11$dd6boCqeH4WwfNuQy9o0m.diA73qUUkwyflNS2oLyCNfMXk1kgV0e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7e892c70-763f-456e-b392-cb9211e681d3"),
                column: "HashPassword",
                value: "$2a$11$ob2AfJ2iEH4UGhAlHWf/j.SKKRsdiejR.wLNk/Fq0eRBt9ld26pKm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58"),
                column: "HashPassword",
                value: "$2a$11$EQLIzSqPkfpkmSWICMqL3uxNw0DDL.eTHx6vrDCHKOR2XS0C06EdC");
        }
    }
}
