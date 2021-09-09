using Microsoft.EntityFrameworkCore.Migrations;

namespace Payroll_Ap.Migrations
{
    public partial class newupdatedmigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "others",
                table: "Employees",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true,
                oldDefaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "others",
                table: "Employees",
                type: "real",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
