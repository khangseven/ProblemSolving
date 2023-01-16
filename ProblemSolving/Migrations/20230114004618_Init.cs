using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProblemSolving.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar", nullable: false),
                    Content = table.Column<string>(type: "varchar", nullable: false),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Createat = table.Column<DateTime>(name: "Create_at", type: "datetime2", nullable: false),
                    Updateat = table.Column<DateTime>(name: "Update_at", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Post_PrimaryKey_PostId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar", nullable: false),
                    PassWord = table.Column<string>(type: "varchar", nullable: false),
                    FullName = table.Column<string>(type: "varchar", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_PrimaryKey_UserId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    PostId = table.Column<Guid>(name: "Post_Id", type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(name: "User_Id", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "Stars_ForeignKey_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Stars_ForeignKey_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stars_User_Id",
                table: "Stars",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
