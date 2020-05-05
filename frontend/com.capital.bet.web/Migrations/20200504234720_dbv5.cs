using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class dbv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("094ffab4-daca-4d25-8dd3-dc9f70056cdb"),
                column: "Features",
                value: "Free Account");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("56f920ef-d83d-4c5f-a1f5-15507d0541d8"),
                column: "Features",
                value: "Standard Account");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("5d8e21fd-5193-41e6-bad6-0fb6ddd3907a"),
                column: "Features",
                value: "Beginner Account");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("a705b56d-2467-47f6-843e-9d6d9537d228"),
                column: "Features",
                value: "Professional Account");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "36c9675d-c4c0-4d8e-90eb-bed30e6d998b", new DateTime(2020, 5, 4, 19, 47, 19, 531, DateTimeKind.Local).AddTicks(4267), new DateTime(2020, 5, 4, 19, 47, 19, 531, DateTimeKind.Local).AddTicks(4271) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "c53eeec6-c5d5-4470-b309-530876d44c95", new DateTime(2020, 5, 4, 19, 47, 19, 531, DateTimeKind.Local).AddTicks(4226), new DateTime(2020, 5, 4, 19, 47, 19, 531, DateTimeKind.Local).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "d573d707-a472-4c31-b793-52988a375b5d", new DateTime(2020, 5, 4, 19, 47, 19, 528, DateTimeKind.Local).AddTicks(9475), new DateTime(2020, 5, 4, 19, 47, 19, 531, DateTimeKind.Local).AddTicks(3673) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("094ffab4-daca-4d25-8dd3-dc9f70056cdb"),
                column: "Features",
                value: "");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("56f920ef-d83d-4c5f-a1f5-15507d0541d8"),
                column: "Features",
                value: "");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("5d8e21fd-5193-41e6-bad6-0fb6ddd3907a"),
                column: "Features",
                value: "");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("a705b56d-2467-47f6-843e-9d6d9537d228"),
                column: "Features",
                value: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "7d736bd8-73e8-4028-91f4-1ee2c216cb6c", new DateTime(2020, 5, 4, 19, 17, 29, 957, DateTimeKind.Local).AddTicks(6989), new DateTime(2020, 5, 4, 19, 17, 29, 957, DateTimeKind.Local).AddTicks(6993) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "a2705076-a111-4ced-bc15-e59c185d202e", new DateTime(2020, 5, 4, 19, 17, 29, 957, DateTimeKind.Local).AddTicks(6945), new DateTime(2020, 5, 4, 19, 17, 29, 957, DateTimeKind.Local).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "69c1336f-53d7-4ca3-88a5-2cad5c48ee77", new DateTime(2020, 5, 4, 19, 17, 29, 954, DateTimeKind.Local).AddTicks(9599), new DateTime(2020, 5, 4, 19, 17, 29, 957, DateTimeKind.Local).AddTicks(6310) });
        }
    }
}
