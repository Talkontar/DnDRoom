using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDRoom.Data.Migrations
{
    public partial class changeRoomUserRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room_Users");

            migrationBuilder.CreateTable(
                name: "RoomUser",
                columns: table => new
                {
                    ConnectedRoomsId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomUser", x => new { x.ConnectedRoomsId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_RoomUser_AspNetUsers_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoomUser_Rooms_ConnectedRoomsId",
                        column: x => x.ConnectedRoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomUser_PlayersId",
                table: "RoomUser",
                column: "PlayersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomUser");

            migrationBuilder.CreateTable(
                name: "Room_Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Users", x => new { x.UserId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_Room_Users_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_Users_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_Users_RoomId",
                table: "Room_Users",
                column: "RoomId");
        }
    }
}
