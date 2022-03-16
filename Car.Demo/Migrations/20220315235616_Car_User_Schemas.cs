using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Demo.Migrations
{
    /// <inheritdoc />
    public partial class Car_User_Schemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    LastChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Users_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashPassword", "Name", "PhoneNumber", "Role" },
                values: new object[] { new Guid("26af7842-53e0-4680-96cb-8c02a696e59f"), "l.wilkins@gmail.com", "$2a$11$dd6boCqeH4WwfNuQy9o0m.diA73qUUkwyflNS2oLyCNfMXk1kgV0e", "Lacey Wilkins", "0683006024", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashPassword", "Name", "PhoneNumber", "Role" },
                values: new object[] { new Guid("7e892c70-763f-456e-b392-cb9211e681d3"), "s.newman@gmail.com", "$2a$11$ob2AfJ2iEH4UGhAlHWf/j.SKKRsdiejR.wLNk/Fq0eRBt9ld26pKm", "Safwan Newman", "0683006024", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashPassword", "Name", "PhoneNumber", "Role" },
                values: new object[] { new Guid("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58"), "c.basset@gmail.com", "$2a$11$EQLIzSqPkfpkmSWICMqL3uxNw0DDL.eTHx6vrDCHKOR2XS0C06EdC", "Celeste Bassett", "0683006027", 1 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Country", "Model", "Price", "PublisherId" },
                values: new object[] { new Guid("73e35e11-ec5c-477b-a491-b8ce2bb5e922"), "BMW", "Germany", "X5", 25000.0, new Guid("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Country", "Model", "Price", "PublisherId" },
                values: new object[] { new Guid("7dc52b77-dbce-4fd7-b48a-069dbc2d5b40"), "Audi", "Germany", "A5", 20000.0, new Guid("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Country", "Model", "Price", "PublisherId" },
                values: new object[] { new Guid("ca0cde35-50b0-49e5-8534-f0aa08115d76"), "Mercedes", "Germany", "CLS", 30000.0, new Guid("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58") });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PublisherId",
                table: "Cars",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
