using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class dbv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "TypeId", "Bouns", "CreatedBy", "CreatedDate", "DailyTradeLimit", "Features", "MaxTradeLimit", "MinTradeLimit", "MinimumDeposit", "Name", "UpdatedBy", "UpdatedDate", "WithdrawWaitTime" },
                values: new object[,]
                {
                    { new Guid("094ffab4-daca-4d25-8dd3-dc9f70056cdb"), 0m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "", 100m, 1m, 100m, "Free Account", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 604800000L },
                    { new Guid("5d8e21fd-5193-41e6-bad6-0fb6ddd3907a"), 0.1m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "", 100m, 1m, 1000m, "Beginner Account", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172800000L },
                    { new Guid("56f920ef-d83d-4c5f-a1f5-15507d0541d8"), 0.3m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "", 100m, 1m, 3000m, "Standard Account", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86400000L },
                    { new Guid("a705b56d-2467-47f6-843e-9d6d9537d228"), 0.5m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, "", 1000m, 1m, 5000m, "Professional Account", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86400000L }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("094ffab4-daca-4d25-8dd3-dc9f70056cdb"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("56f920ef-d83d-4c5f-a1f5-15507d0541d8"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("5d8e21fd-5193-41e6-bad6-0fb6ddd3907a"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("a705b56d-2467-47f6-843e-9d6d9537d228"));

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
        }
    }
}
