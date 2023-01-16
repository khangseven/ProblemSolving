using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProblemSolving.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLengthOfVarcharColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "Users",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "Users",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);
        }
    }
}
