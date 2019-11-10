using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCredit.Api.Migrations
{
    public partial class AddSurCharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SurCharge",
                table: "Payments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurCharge",
                table: "Payments");
        }
    }
}
