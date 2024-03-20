using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Championship.Migrations
{
    /// <inheritdoc />
    public partial class AddGames2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamId1",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamId2",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId2",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId1",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_TeamId1",
                table: "Games",
                column: "TeamId1",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_TeamId2",
                table: "Games",
                column: "TeamId2",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamId1",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamId2",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId2",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId1",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_TeamId1",
                table: "Games",
                column: "TeamId1",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_TeamId2",
                table: "Games",
                column: "TeamId2",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
