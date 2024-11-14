using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Shifts_ShiftId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Users_PlayerId",
                table: "Application");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_Application_ShiftId",
                table: "Applications",
                newName: "IX_Applications_ShiftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                columns: new[] { "PlayerId", "ShiftId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Shifts_ShiftId",
                table: "Applications",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_PlayerId",
                table: "Applications",
                column: "PlayerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Shifts_ShiftId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_PlayerId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ShiftId",
                table: "Application",
                newName: "IX_Application_ShiftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                columns: new[] { "PlayerId", "ShiftId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Shifts_ShiftId",
                table: "Application",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Users_PlayerId",
                table: "Application",
                column: "PlayerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
