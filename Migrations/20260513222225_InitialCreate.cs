using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SElab5.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Users_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Hearings",
                columns: table => new
                {
                    HearingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CitizenID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Transcript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hearings", x => x.HearingID);
                    table.ForeignKey(
                        name: "FK_Hearings_Users_CitizenID",
                        column: x => x.CitizenID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hearings_Users_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Documents_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_Documents_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_Requests_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_Requests_Users_CitizenID",
                        column: x => x.CitizenID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerID",
                table: "Departments",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DepartmentID",
                table: "Documents",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_OwnerID",
                table: "Documents",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID",
                table: "Employees",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Hearings_CitizenID",
                table: "Hearings",
                column: "CitizenID");

            migrationBuilder.CreateIndex(
                name: "IX_Hearings_EmployeeID",
                table: "Hearings",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CitizenID",
                table: "Requests",
                column: "CitizenID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DepartmentID",
                table: "Requests",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Hearings");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
