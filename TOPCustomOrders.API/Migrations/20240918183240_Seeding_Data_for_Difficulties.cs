using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TOPCustomOrders.API.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Data_for_Difficulties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4a3549ea-34f5-44e3-87c1-e8447bcd198e"),
                column: "Name",
                value: "Hard");

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4c6964a9-31b9-40f6-9b39-678b2b08f6b2"),
                column: "Name",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fa549bb2-8fb4-404b-ae85-6f3695578dd0"),
                column: "Name",
                value: "Easy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4a3549ea-34f5-44e3-87c1-e8447bcd198e"),
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4c6964a9-31b9-40f6-9b39-678b2b08f6b2"),
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fa549bb2-8fb4-404b-ae85-6f3695578dd0"),
                column: "Name",
                value: "");
        }
    }
}
