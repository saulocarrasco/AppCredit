using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCredit.Api.Migrations
{
    public partial class AddSurchargeToFeeInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SurCharge",
                table: "FeeInformations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurCharge",
                table: "FeeInformations");
        }
    }
}
