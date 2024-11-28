using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TypoUserFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirdth",
                table: "Users",
                newName: "DateOfBirth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "DateOfBirdth");
        }
    }
}
