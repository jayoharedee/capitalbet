using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultCharacter",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultCharacter",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "23bcd3f3-985a-4866-8a24-675d3f9bc986", new DateTime(2020, 5, 4, 2, 33, 0, 49, DateTimeKind.Local).AddTicks(4150), new DateTime(2020, 5, 4, 2, 33, 0, 49, DateTimeKind.Local).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "2bb0ad88-f426-41a5-9f2b-0fec58c60746", new DateTime(2020, 5, 4, 2, 33, 0, 49, DateTimeKind.Local).AddTicks(4087), new DateTime(2020, 5, 4, 2, 33, 0, 49, DateTimeKind.Local).AddTicks(4107) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "199980d6-eac1-4be0-bf47-d8be9241a4ee", new DateTime(2020, 5, 4, 2, 33, 0, 46, DateTimeKind.Local).AddTicks(9411), new DateTime(2020, 5, 4, 2, 33, 0, 49, DateTimeKind.Local).AddTicks(3522) });
        }
    }
}
