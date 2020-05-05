using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class Dv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "9bfd799a-d704-45cc-9ff9-921e2afb99a1", new DateTime(2020, 5, 5, 10, 38, 59, 41, DateTimeKind.Local).AddTicks(3233), new DateTime(2020, 5, 5, 10, 38, 59, 41, DateTimeKind.Local).AddTicks(3237) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "4a5e83ec-cfee-47a5-9838-bd3e980cb96a", new DateTime(2020, 5, 5, 10, 38, 59, 41, DateTimeKind.Local).AddTicks(3171), new DateTime(2020, 5, 5, 10, 38, 59, 41, DateTimeKind.Local).AddTicks(3193) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "1ee85519-ab4d-4fd2-bd03-1657929a7959", new DateTime(2020, 5, 5, 10, 38, 59, 38, DateTimeKind.Local).AddTicks(6058), new DateTime(2020, 5, 5, 10, 38, 59, 41, DateTimeKind.Local).AddTicks(2473) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "b79b3f42-6ae0-4b9a-b963-cad69e8a62c9", new DateTime(2020, 5, 5, 1, 9, 17, 647, DateTimeKind.Local).AddTicks(1429), new DateTime(2020, 5, 5, 1, 9, 17, 647, DateTimeKind.Local).AddTicks(1433) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "db18bad7-0e96-43d0-9f05-1aea3925a020", new DateTime(2020, 5, 5, 1, 9, 17, 647, DateTimeKind.Local).AddTicks(1382), new DateTime(2020, 5, 5, 1, 9, 17, 647, DateTimeKind.Local).AddTicks(1408) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "e1c65d26-7aeb-4ffa-be23-71e700447621", new DateTime(2020, 5, 5, 1, 9, 17, 644, DateTimeKind.Local).AddTicks(6677), new DateTime(2020, 5, 5, 1, 9, 17, 647, DateTimeKind.Local).AddTicks(795) });
        }
    }
}
