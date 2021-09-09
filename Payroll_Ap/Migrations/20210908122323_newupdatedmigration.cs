using Microsoft.EntityFrameworkCore.Migrations;

namespace Payroll_Ap.Migrations
{
    public partial class newupdatedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deductions");

            migrationBuilder.DropTable(
                name: "Payrolls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Advance = table.Column<float>(type: "real", nullable: false),
                    Court = table.Column<float>(type: "real", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guard = table.Column<float>(type: "real", nullable: true),
                    Others = table.Column<float>(type: "real", nullable: true),
                    Pension = table.Column<float>(type: "real", nullable: true),
                    Saving = table.Column<float>(type: "real", nullable: true),
                    Tax = table.Column<float>(type: "real", nullable: true),
                    Total_Deduction = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payrolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Absent = table.Column<float>(type: "real", nullable: false),
                    Allowance = table.Column<float>(type: "real", nullable: false),
                    Deduction = table.Column<float>(type: "real", nullable: false),
                    Gross = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetSalary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payrolls", x => x.Id);
                });
        }
    }
}
