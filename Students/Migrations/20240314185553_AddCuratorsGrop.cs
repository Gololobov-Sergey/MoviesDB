using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.Migrations
{
    /// <inheritdoc />
    public partial class AddCuratorsGrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuratorId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CuratorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CuratorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CuratorId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CuratorId",
                table: "Groups",
                column: "CuratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Curators_CuratorId",
                table: "Groups",
                column: "CuratorId",
                principalTable: "Curators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Curators_CuratorId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CuratorId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CuratorId",
                table: "Groups");
        }
    }
}
