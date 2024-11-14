using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventsAndGroupsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventGroup",
                columns: table => new
                {
                    EventsEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupsGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGroup", x => new { x.EventsEventId, x.GroupsGroupId });
                    table.ForeignKey(
                        name: "FK_EventGroup_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGroup_Group_GroupsGroupId",
                        column: x => x.GroupsGroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestingRecords",
                columns: table => new
                {
                    TestingRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BodyFatPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SprintTime = table.Column<int>(type: "int", nullable: false),
                    JumpHeightCm = table.Column<int>(type: "int", nullable: false),
                    PushUpCount = table.Column<int>(type: "int", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingRecords", x => x.TestingRecordId);
                    table.ForeignKey(
                        name: "FK_TestingRecords_Users_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventGroup_GroupsGroupId",
                table: "EventGroup",
                column: "GroupsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TestingRecords_PlayerId",
                table: "TestingRecords",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventGroup");

            migrationBuilder.DropTable(
                name: "TestingRecords");
        }
    }
}
