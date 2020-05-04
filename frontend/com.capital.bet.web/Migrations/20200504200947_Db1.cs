using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class Db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "CreatedBy", "CreatedDate", "Description", "Enabled", "Name", "PayOutRate", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { "EUR_CAD", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR/CAD", true, "EUR/CAD", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AUD_JPY", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD/JPY", true, "AUD/JPY", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AUD_CAD", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD/CAD", true, "AUD/CAD", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "GBP_JPY", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP/JPY", true, "GBP/JPY", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "CAD_JPY", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAD/JPY", true, "CAD/JPY", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "EUR_AUD", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR/AUD", true, "EUR/AUD", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "BTC_EUR", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BTC/EUR", true, "BTC/EUR", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "EUR_GBP", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR/GBP", true, "EUR/GBP", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "USD_CAD", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD/CAD", true, "USD/CAD", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AUD_USD", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD/USD", true, "AUD/USD", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "USD_JPY", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD/JPY", true, "USD/JPY", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "EUR_JPY", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR/JPY", true, "EUR/JPY", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "GBP_USD", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP/USD", true, "GBP/USD", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "BTC_USD", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BTC/USD", true, "BTC/USD", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "EUR_USD", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR/USD", true, "EUR/USD", 0.6m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "AUD_CAD");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "AUD_JPY");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "AUD_USD");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "BTC_EUR");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "BTC_USD");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "CAD_JPY");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "EUR_AUD");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "EUR_CAD");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "EUR_GBP");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "EUR_JPY");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "EUR_USD");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "GBP_JPY");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "GBP_USD");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "USD_CAD");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: "USD_JPY");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "856c560a-43b0-42f5-982d-5be5d2522f2c", new DateTime(2020, 5, 4, 15, 34, 13, 747, DateTimeKind.Local).AddTicks(3923), new DateTime(2020, 5, 4, 15, 34, 13, 747, DateTimeKind.Local).AddTicks(3927) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "789c11bc-f6e2-4c33-85a1-a9b676192134", new DateTime(2020, 5, 4, 15, 34, 13, 747, DateTimeKind.Local).AddTicks(3879), new DateTime(2020, 5, 4, 15, 34, 13, 747, DateTimeKind.Local).AddTicks(3902) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "fbd97d19-9e74-4a57-9c1f-8788db0a10c2", new DateTime(2020, 5, 4, 15, 34, 13, 744, DateTimeKind.Local).AddTicks(5556), new DateTime(2020, 5, 4, 15, 34, 13, 747, DateTimeKind.Local).AddTicks(3158) });
        }
    }
}
