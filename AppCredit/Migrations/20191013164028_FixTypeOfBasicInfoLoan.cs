using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCredit.Api.Migrations
{
    public partial class FixTypeOfBasicInfoLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LoanAmount",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossProfit",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LoanAmount",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "GrossProfit",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
