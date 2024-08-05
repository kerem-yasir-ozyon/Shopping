using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdminuserandAdminroleInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, null, "Admin", "ADMİN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName", "gender" },
                values: new object[] { 1, 0, new DateOnly(1999, 1, 1), "de17243b-c0ca-4dcb-bbdc-77ba373341c8", "Admin@mail.com", true, false, null, "Admin", "ADMİN@MAİL.COM", "ADMİN", "AQAAAAIAAYagAAAAEBY/XeHm9kihJrsqih3dhLwBFH+I0S2+bVShqQg7O0xJf/Wg7L5+AH7Op+rtwC1B4Q==", "-", true, null, "Admin", false, "Admin", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
