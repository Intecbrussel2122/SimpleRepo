using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleRepo.Migrations
{
    public partial class AddedrelationinEmployeewithemployeCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeCVs_EmployeeId",
                table: "EmployeeCVs");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCVs_EmployeeId",
                table: "EmployeeCVs",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeCVs_EmployeeId",
                table: "EmployeeCVs");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCVs_EmployeeId",
                table: "EmployeeCVs",
                column: "EmployeeId");
        }
    }
}
