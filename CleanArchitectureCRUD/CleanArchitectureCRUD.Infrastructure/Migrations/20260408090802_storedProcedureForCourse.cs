using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureCRUD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class storedProcedureForCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // stored procedure for addAsync() method
            var sp = @"
CREATE OR ALTER PROCEDURE [dbo].[spAddCourse]
    @CourseId UNIQUEIDENTIFIER,
    @CourseName NVARCHAR(MAX),
    @InstructorId UNIQUEIDENTIFIER,
    @Credit INT
AS 
BEGIN
    INSERT INTO Courses (CourseId, CourseName, InstructorId, Credit)
    VALUES (@CourseId, @CourseName, @InstructorId, @Credit);

END
";
            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[spAddCourse]");
        }
    }
}
