using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class dbv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserAccounts_AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "4c252873-a3a3-4fce-94f3-869f16bf7da9", new DateTime(2020, 5, 5, 1, 0, 48, 941, DateTimeKind.Local).AddTicks(2123), new DateTime(2020, 5, 5, 1, 0, 48, 941, DateTimeKind.Local).AddTicks(2127) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "fa9d7e7a-7dc2-45e4-a7ab-76fa75c582ee", new DateTime(2020, 5, 5, 1, 0, 48, 941, DateTimeKind.Local).AddTicks(2080), new DateTime(2020, 5, 5, 1, 0, 48, 941, DateTimeKind.Local).AddTicks(2104) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "5bade07d-f3e5-4fc3-b291-97f5476709cf", new DateTime(2020, 5, 5, 1, 0, 48, 938, DateTimeKind.Local).AddTicks(5403), new DateTime(2020, 5, 5, 1, 0, 48, 941, DateTimeKind.Local).AddTicks(1465) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserAccounts_AccountId",
                table: "AspNetUsers",
                column: "AccountId",
                principalTable: "UserAccounts",
                principalColumn: "AcountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
