using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw8.Migrations
{
    public partial class addedaccountidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.AddPrimaryKey(
                name: "User_PK",
                table: "Accounts",
                column: "IdAccount");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 0, 6, 254, DateTimeKind.Local).AddTicks(341), new DateTime(2022, 6, 23, 12, 0, 6, 257, DateTimeKind.Local).AddTicks(6834) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "User_PK",
                table: "Accounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "IdAccount");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2022, 6, 22, 11, 51, 53, 513, DateTimeKind.Local).AddTicks(2922), new DateTime(2022, 6, 23, 11, 51, 53, 517, DateTimeKind.Local).AddTicks(914) });
        }
    }
}
