using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.capital.bet.web.Migrations
{
    public partial class edc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_AspNetUsers_UserId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_UserId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Options");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Options",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Options",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818352ca-d178-407b-b8f4-48ac2ee6f3ac",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "1720ec27-b480-4a90-b900-08205bf564d1", new DateTime(2020, 5, 7, 14, 34, 41, 704, DateTimeKind.Local).AddTicks(3564), new DateTime(2020, 5, 7, 14, 34, 41, 704, DateTimeKind.Local).AddTicks(3568) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974be833-b074-4778-9b74-ca83e601dbbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "8c90a9ef-6ab0-4d45-afd1-97e15640f0b6", new DateTime(2020, 5, 7, 14, 34, 41, 704, DateTimeKind.Local).AddTicks(3520), new DateTime(2020, 5, 7, 14, 34, 41, 704, DateTimeKind.Local).AddTicks(3543) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb210f02-c9df-4bf3-8ea4-351852ddc432",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "9b4a15f5-5e52-464e-9c11-37d707110cbb", new DateTime(2020, 5, 7, 14, 34, 41, 701, DateTimeKind.Local).AddTicks(8015), new DateTime(2020, 5, 7, 14, 34, 41, 704, DateTimeKind.Local).AddTicks(2899) });

            migrationBuilder.CreateIndex(
                name: "IX_Options_ApplicationUserId",
                table: "Options",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_AspNetUsers_ApplicationUserId",
                table: "Options",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_AspNetUsers_ApplicationUserId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_ApplicationUserId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Options");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Options",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Options_UserId",
                table: "Options",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_AspNetUsers_UserId",
                table: "Options",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
