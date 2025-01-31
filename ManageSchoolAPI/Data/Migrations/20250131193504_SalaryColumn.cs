using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageSchoolAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class SalaryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Employee_TeacherEmployeeId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Student_TeacherEmployeeId",
                table: "Students",
                newName: "IX_Students_TeacherEmployeeId");

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Employee",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Employee_TeacherEmployeeId",
                table: "Students",
                column: "TeacherEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Employee_TeacherEmployeeId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Students_TeacherEmployeeId",
                table: "Student",
                newName: "IX_Student_TeacherEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Employee_TeacherEmployeeId",
                table: "Student",
                column: "TeacherEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }
    }
}
