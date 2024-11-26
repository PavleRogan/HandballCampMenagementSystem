using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class campEventsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Shifts_ShiftId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPlayer_Group_GroupsGroupId",
                table: "GroupPlayer");

            migrationBuilder.DropTable(
                name: "EventGroup");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Group_ShiftId",
                table: "Groups",
                newName: "IX_Groups_ShiftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "GroupId");

            migrationBuilder.CreateTable(
                name: "CampEvents",
                columns: table => new
                {
                    CampEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampEvents", x => x.CampEventId);
                });

            migrationBuilder.CreateTable(
                name: "CampEventGroup",
                columns: table => new
                {
                    CampEventsCampEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupsGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampEventGroup", x => new { x.CampEventsCampEventId, x.GroupsGroupId });
                    table.ForeignKey(
                        name: "FK_CampEventGroup_CampEvents_CampEventsCampEventId",
                        column: x => x.CampEventsCampEventId,
                        principalTable: "CampEvents",
                        principalColumn: "CampEventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampEventGroup_Groups_GroupsGroupId",
                        column: x => x.GroupsGroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampEventGroup_GroupsGroupId",
                table: "CampEventGroup",
                column: "GroupsGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPlayer_Groups_GroupsGroupId",
                table: "GroupPlayer",
                column: "GroupsGroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Shifts_ShiftId",
                table: "Groups",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupPlayer_Groups_GroupsGroupId",
                table: "GroupPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Shifts_ShiftId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "CampEventGroup");

            migrationBuilder.DropTable(
                name: "CampEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ShiftId",
                table: "Group",
                newName: "IX_Group_ShiftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "GroupId");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EventGroup_GroupsGroupId",
                table: "EventGroup",
                column: "GroupsGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Shifts_ShiftId",
                table: "Group",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPlayer_Group_GroupsGroupId",
                table: "GroupPlayer",
                column: "GroupsGroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
