using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SeasonId",
                table: "Shifts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfApply = table.Column<DateOnly>(type: "date", nullable: false),
                    StatusOfApplication = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => new { x.PlayerId, x.ShiftId });
                    table.ForeignKey(
                        name: "FK_Application_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_Users_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_SeasonId",
                table: "Shifts",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ShiftId",
                table: "Application",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Seasons_SeasonId",
                table: "Shifts",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Seasons_SeasonId",
                table: "Shifts");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_SeasonId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Shifts");
        }
    }
}
