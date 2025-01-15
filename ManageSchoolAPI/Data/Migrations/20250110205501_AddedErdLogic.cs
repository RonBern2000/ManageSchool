using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageSchoolAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedErdLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jenitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "Professions",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeType",
                table: "Employee",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManagerUserId",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    TeacherEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Employee_TeacherEmployeeId",
                        column: x => x.TeacherEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerUserId",
                table: "Employee",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_TeacherEmployeeId",
                table: "Student",
                column: "TeacherEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Users_ManagerUserId",
                table: "Employee",
                column: "ManagerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Users_ManagerUserId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ManagerUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ManagerUserId",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "Professions",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "Jenitors",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jenitors", x => x.EmployeeId);
                });
        }
    }
}
