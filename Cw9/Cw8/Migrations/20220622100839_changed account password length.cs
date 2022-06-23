using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw8.Migrations
{
    public partial class changedaccountpasswordlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "User_PK",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "IdAccount");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 8, 39, 136, DateTimeKind.Local).AddTicks(6110), new DateTime(2022, 6, 23, 12, 8, 39, 139, DateTimeKind.Local).AddTicks(7233) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
    }
}
