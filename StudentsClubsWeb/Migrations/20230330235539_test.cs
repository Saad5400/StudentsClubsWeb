using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsClubsWeb.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubAdmin_AspNetUsers_AdminId",
                table: "ClubAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubAdmin_Clubs_ClubId",
                table: "ClubAdmin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubAdmin",
                table: "ClubAdmin");

            migrationBuilder.RenameTable(
                name: "ClubAdmin",
                newName: "ClubAdmins");

            migrationBuilder.RenameIndex(
                name: "IX_ClubAdmin_ClubId",
                table: "ClubAdmins",
                newName: "IX_ClubAdmins_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_ClubAdmin_AdminId",
                table: "ClubAdmins",
                newName: "IX_ClubAdmins_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubAdmins",
                table: "ClubAdmins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubAdmins_AspNetUsers_AdminId",
                table: "ClubAdmins",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubAdmins_Clubs_ClubId",
                table: "ClubAdmins",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubAdmins_AspNetUsers_AdminId",
                table: "ClubAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubAdmins_Clubs_ClubId",
                table: "ClubAdmins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubAdmins",
                table: "ClubAdmins");

            migrationBuilder.RenameTable(
                name: "ClubAdmins",
                newName: "ClubAdmin");

            migrationBuilder.RenameIndex(
                name: "IX_ClubAdmins_ClubId",
                table: "ClubAdmin",
                newName: "IX_ClubAdmin_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_ClubAdmins_AdminId",
                table: "ClubAdmin",
                newName: "IX_ClubAdmin_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubAdmin",
                table: "ClubAdmin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubAdmin_AspNetUsers_AdminId",
                table: "ClubAdmin",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubAdmin_Clubs_ClubId",
                table: "ClubAdmin",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
