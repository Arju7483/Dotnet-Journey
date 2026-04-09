using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitectureCRUD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCourseSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Credit", "InstructorId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567801"), "Introduction to C#", 3, new Guid("f73fb6b0-9618-4dc9-0008-08de90cf5197"), null },
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567802"), "ASP.NET Core Web API", 4, new Guid("74fbbc2f-7ace-4b00-0009-08de90cf5197"), null },
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567803"), "Entity Framework Core", 3, new Guid("f73fb6b0-9618-4dc9-0008-08de90cf5197"), null },
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567804"), "Clean Architecture Principles", 4, new Guid("74fbbc2f-7ace-4b00-0009-08de90cf5197"), null },
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567805"), "Design Patterns in .NET", 3, new Guid("f73fb6b0-9618-4dc9-0008-08de90cf5197"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentId",
                table: "Courses",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
