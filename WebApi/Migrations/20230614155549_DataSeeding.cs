using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0f1d41e8-f929-4f99-b0a7-f82d3ce557e9"), "IPAD", null, "IPad", 10m, 34 },
                    { new Guid("1dcc375d-752e-4e2d-bea0-571bb849ac46"), "Mobiles", null, "Mobile Phone", 12m, 1308 },
                    { new Guid("5c12b6b1-26be-454a-b32e-fee36d0853c1"), "PC One", null, "PC", 10m, 120 },
                    { new Guid("7d0bc73f-89ec-48d4-8417-2d7e785aec77"), "Smart Watch", null, "Smart Watch", 15m, 500 },
                    { new Guid("7e87e47d-bd80-4f0f-8eca-a70764079dd0"), "TV", null, "Television", 12m, 340 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "302ff4a8-93b3-4680-a328-f327ebff24f0", 0, "13b7cad7-cb26-474f-9246-f4730a6f64ea", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ADMIN@TEST.COM", false, "", false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "$2a$11$LNKgzaeYMjV9iS/rj4WeieJpKNj8LxY2e/cjTcIfdtDo0cXELwsby", null, false, "b4c1dafb-2f06-4fb8-804f-2e6f5e792ef3", false, "admin@test.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f1d41e8-f929-4f99-b0a7-f82d3ce557e9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1dcc375d-752e-4e2d-bea0-571bb849ac46"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5c12b6b1-26be-454a-b32e-fee36d0853c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d0bc73f-89ec-48d4-8417-2d7e785aec77"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e87e47d-bd80-4f0f-8eca-a70764079dd0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "302ff4a8-93b3-4680-a328-f327ebff24f0");
        }
    }
}
