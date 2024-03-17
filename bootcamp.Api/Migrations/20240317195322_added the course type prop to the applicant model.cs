using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bootcamp.Api.Migrations
{
    /// <inheritdoc />
    public partial class addedthecoursetypeproptotheapplicantmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseType",
                table: "Applicants",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseType",
                table: "Applicants");
        }
    }
}
