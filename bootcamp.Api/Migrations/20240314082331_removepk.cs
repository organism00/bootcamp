using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bootcamp.Api.Migrations
{
    /// <inheritdoc />
    public partial class removepk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Students_StudentId",
                table: "Applicants");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Applicants",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Students_StudentId",
                table: "Applicants",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Students_StudentId",
                table: "Applicants");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Applicants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Students_StudentId",
                table: "Applicants",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
