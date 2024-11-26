using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CoachEventsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CampEvents_CoachId",
                table: "CampEvents",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampEvents_Users_CoachId",
                table: "CampEvents",
                column: "CoachId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampEvents_Users_CoachId",
                table: "CampEvents");

            migrationBuilder.DropIndex(
                name: "IX_CampEvents_CoachId",
                table: "CampEvents");
        }
    }
}
