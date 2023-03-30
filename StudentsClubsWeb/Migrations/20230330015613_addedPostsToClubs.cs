using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsClubsWeb.Migrations
{
    public partial class addedPostsToClubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ClubId",
                table: "Posts",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Clubs_ClubId",
                table: "Posts",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Clubs_ClubId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ClubId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Posts");
        }
    }
}
