using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class Dv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "ed17b6ee-a35e-41e2-9c8e-6e7ab23fd45d", new DateTime(2020, 5, 5, 11, 54, 34, 353, DateTimeKind.Local).AddTicks(8500), new DateTime(2020, 5, 5, 11, 54, 34, 353, DateTimeKind.Local).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "2153237d-e3d3-41d3-a317-8c3e43e1a6b9", new DateTime(2020, 5, 5, 11, 54, 34, 353, DateTimeKind.Local).AddTicks(8457), new DateTime(2020, 5, 5, 11, 54, 34, 353, DateTimeKind.Local).AddTicks(8480) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "21ec1ba5-bddc-4087-8782-85c4427c2d1f", new DateTime(2020, 5, 5, 11, 54, 34, 351, DateTimeKind.Local).AddTicks(2902), new DateTime(2020, 5, 5, 11, 54, 34, 353, DateTimeKind.Local).AddTicks(7765) });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "TypeId", "Deacription", "Name" },
                values: new object[,]
                {
                    { 1, "The user deposited funds into their account.", "Deposit Funds" },
                    { 2, "The user has had funds removed from a failed trade.", "Trade Loss" },
                    { 3, "The user has gained funds in their account from a successful trade.", "Trade Gain" },
                    { 4, "The user has withdrawn funds from their account.", "Withdraw Funds" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "TypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "TypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "TypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "TypeId",
                keyValue: 4);

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
    }
}
