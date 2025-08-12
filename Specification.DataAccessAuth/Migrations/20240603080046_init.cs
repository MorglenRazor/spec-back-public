using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Specification.DataAccessAuth.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase().Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "departments",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(
                            type: "char(36)",
                            nullable: false,
                            collation: "ascii_general_ci"
                        ),
                        DepartmentName = table
                            .Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        DepShortName = table
                            .Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4")
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_departments", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "roles",
                    columns: table => new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation(
                                "MySql:ValueGenerationStrategy",
                                MySqlValueGenerationStrategy.IdentityColumn
                            ),
                        NameRole = table
                            .Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4")
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_roles", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "employers",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(
                            type: "char(36)",
                            nullable: false,
                            collation: "ascii_general_ci"
                        ),
                        UserName = table
                            .Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Password = table
                            .Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        FullName = table
                            .Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        ShortName = table
                            .Column<string>(type: "varchar(155)", maxLength: 155, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        PhoneNumber = table
                            .Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        PositionName = table
                            .Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        DepartmentId = table.Column<Guid>(
                            type: "char(36)",
                            nullable: false,
                            collation: "ascii_general_ci"
                        )
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_employers", x => x.Id);
                        table.ForeignKey(
                            name: "FK_employers_departments_DepartmentId",
                            column: x => x.DepartmentId,
                            principalTable: "departments",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "UserRoles",
                    columns: table => new
                    {
                        UserId = table.Column<Guid>(
                            type: "char(36)",
                            nullable: false,
                            collation: "ascii_general_ci"
                        ),
                        RoleId = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                        table.ForeignKey(
                            name: "FK_UserRoles_employers_UserId",
                            column: x => x.UserId,
                            principalTable: "employers",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                        table.ForeignKey(
                            name: "FK_UserRoles_roles_RoleId",
                            column: x => x.RoleId,
                            principalTable: "roles",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "NameRole" },
                values: new object[,]
                {
                    { 1, "Developer" },
                    { 2, "Admin" },
                    { 3, "EngineerCD" },
                    { 4, "EmployeeWD" },
                    { 5, "ControllerTCD" },
                    { 6, "EmployeeMTS" },
                    { 7, "EmployeeAD" },
                    { 8, "User" }
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_employers_DepartmentId",
                table: "employers",
                column: "DepartmentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "UserRoles");

            migrationBuilder.DropTable(name: "employers");

            migrationBuilder.DropTable(name: "roles");

            migrationBuilder.DropTable(name: "departments");
        }
    }
}
