using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProblemSolving.Migrations
{
    /// <inheritdoc />
    public partial class ChangPostContentColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);
        }
    }
}
