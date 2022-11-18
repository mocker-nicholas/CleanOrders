using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanOrders.Infrastructure.Migrations
{
    public partial class updateaccountaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress1",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress2",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StreetAddress1",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StreetAddress2",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                table: "Address",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
