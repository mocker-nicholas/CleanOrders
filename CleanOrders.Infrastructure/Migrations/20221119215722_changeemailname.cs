using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanOrders.Infrastructure.Migrations
{
    public partial class changeemailname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Users",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "EmailAddress");
        }
    }
}
