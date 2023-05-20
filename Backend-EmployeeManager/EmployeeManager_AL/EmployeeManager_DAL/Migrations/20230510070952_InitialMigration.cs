using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManager_DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeUser",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    UsersUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUser", x => new { x.EmployeesEmployeeId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_EmployeeUser_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUser",
                columns: table => new
                {
                    RolesRolId = table.Column<long>(type: "bigint", nullable: false),
                    UsersUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUser", x => new { x.RolesRolId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_RolUser_Roles_RolesRolId",
                        column: x => x.RolesRolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUser_UsersUserId",
                table: "EmployeeUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_UsersUserId",
                table: "RolUser",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeUser");

            migrationBuilder.DropTable(
                name: "RolUser");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
