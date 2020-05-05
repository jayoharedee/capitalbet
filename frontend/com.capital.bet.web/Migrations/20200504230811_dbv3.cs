using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class dbv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "UserAccounts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    TypeId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Features = table.Column<string>(maxLength: 150, nullable: false),
                    WithdrawWaitTime = table.Column<long>(nullable: false),
                    MinTradeLimit = table.Column<decimal>(nullable: false),
                    MaxTradeLimit = table.Column<decimal>(nullable: false),
                    MinimumDeposit = table.Column<decimal>(nullable: false),
                    DailyTradeLimit = table.Column<int>(nullable: false),
                    Bouns = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.TypeId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "06b6d5d2-b2de-4d05-af08-a1820368948c", new DateTime(2020, 5, 4, 19, 8, 11, 48, DateTimeKind.Local).AddTicks(2793), new DateTime(2020, 5, 4, 19, 8, 11, 48, DateTimeKind.Local).AddTicks(2797) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "6529c436-d6f5-4bbd-8bf6-8e2fbcd909bf", new DateTime(2020, 5, 4, 19, 8, 11, 48, DateTimeKind.Local).AddTicks(2752), new DateTime(2020, 5, 4, 19, 8, 11, 48, DateTimeKind.Local).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "fcc92456-5d4b-4cca-b6ed-9a61fade62d0", new DateTime(2020, 5, 4, 19, 8, 11, 45, DateTimeKind.Local).AddTicks(5900), new DateTime(2020, 5, 4, 19, 8, 11, 48, DateTimeKind.Local).AddTicks(2123) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_AccountTypes_AcountId",
                table: "UserAccounts",
                column: "AcountId",
                principalTable: "AccountTypes",
                principalColumn: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_AccountTypes_AcountId",
                table: "UserAccounts");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "UserAccounts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "787a3213-b59c-4688-aaaa-5d4fc01a32bd", new DateTime(2020, 5, 4, 16, 9, 47, 112, DateTimeKind.Local).AddTicks(6563), new DateTime(2020, 5, 4, 16, 9, 47, 112, DateTimeKind.Local).AddTicks(6567) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "3929c1e1-a725-4ba6-a470-32523ac2dda1", new DateTime(2020, 5, 4, 16, 9, 47, 112, DateTimeKind.Local).AddTicks(6506), new DateTime(2020, 5, 4, 16, 9, 47, 112, DateTimeKind.Local).AddTicks(6527) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "c90c8234-65da-4ba9-9a1c-11a148b58b4c", new DateTime(2020, 5, 4, 16, 9, 47, 109, DateTimeKind.Local).AddTicks(9663), new DateTime(2020, 5, 4, 16, 9, 47, 112, DateTimeKind.Local).AddTicks(5864) });
        }
    }
}
