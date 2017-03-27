using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeChallange.Migrations
{
    public partial class FixingInitialErros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team1Id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Team2Id",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Teams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Team1IdTeamId",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team2IdTeamId",
                table: "Matches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MemberId",
                table: "Teams",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team1IdTeamId",
                table: "Matches",
                column: "Team1IdTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team2IdTeamId",
                table: "Matches",
                column: "Team2IdTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Team1IdTeamId",
                table: "Matches",
                column: "Team1IdTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Team2IdTeamId",
                table: "Matches",
                column: "Team2IdTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Members_MemberId",
                table: "Teams",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Team1IdTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Team2IdTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Members_MemberId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_MemberId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Team1IdTeamId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Team2IdTeamId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Team1IdTeamId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Team2IdTeamId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team1Id",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team2Id",
                table: "Matches",
                nullable: false,
                defaultValue: 0);
        }
    }
}
