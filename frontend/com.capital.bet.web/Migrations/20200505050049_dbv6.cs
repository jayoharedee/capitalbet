using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class dbv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_AccountTypes_AcountId",
                table: "UserAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountTypeTypeId",
                table: "UserAccounts",
                nullable: true);

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
                name: "IX_UserAccounts_AccountTypeTypeId",
                table: "UserAccounts",
                column: "AccountTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_AccountTypes_AccountTypeTypeId",
                table: "UserAccounts",
                column: "AccountTypeTypeId",
                principalTable: "AccountTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_AccountTypes_AccountTypeTypeId",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_AccountTypeTypeId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "AccountTypeTypeId",
                table: "UserAccounts");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_AccountTypes_AcountId",
                table: "UserAccounts",
                column: "AcountId",
                principalTable: "AccountTypes",
                principalColumn: "TypeId");
        }
    }
}
