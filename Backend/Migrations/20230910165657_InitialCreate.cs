using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "internshipManagmentDatabase");

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "internshipManagmentDatabase",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    XStart = table.Column<int>(type: "INTEGER", nullable: false),
                    XEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    YStart = table.Column<int>(type: "INTEGER", nullable: false),
                    YEnd = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "internshipManagmentDatabase",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Road",
                schema: "internshipManagmentDatabase",
                columns: table => new
                {
                    RoadId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Road", x => x.RoadId);
                    table.ForeignKey(
                        name: "FK_Road_Room_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "internshipManagmentDatabase",
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Road_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "internshipManagmentDatabase",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Road_RoomId",
                schema: "internshipManagmentDatabase",
                table: "Road",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Road_UserId",
                schema: "internshipManagmentDatabase",
                table: "Road",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Road",
                schema: "internshipManagmentDatabase");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "internshipManagmentDatabase");

            migrationBuilder.DropTable(
                name: "User",
                schema: "internshipManagmentDatabase");
        }
    }
}
