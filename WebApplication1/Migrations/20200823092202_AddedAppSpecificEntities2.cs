using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceApp.Migrations
{
    public partial class AddedAppSpecificEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomFeature");

            migrationBuilder.DropTable(
                name: "RoomSetting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoomMapping",
                table: "UserRoomMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomConfiguration",
                table: "RoomConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b40e0174-d628-4a98-a44e-db4b06254f49");

            migrationBuilder.RenameTable(
                name: "UserRoomMapping",
                newName: "UserRoomMappings");

            migrationBuilder.RenameTable(
                name: "RoomConfiguration",
                newName: "RoomConfigurations");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Meeting",
                newName: "Meetings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoomMappings",
                table: "UserRoomMappings",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomConfigurations",
                table: "RoomConfigurations",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "RoomFeatures",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeatures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomSettings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantID = table.Column<Guid>(nullable: false),
                    FeatureID = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    RoomID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSettings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ModeratorPassword = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantID", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8337047c-3f3f-425d-a635-5b67dde80afa", 0, "f1657ed6-c651-46a5-b63d-5169e72a3dfb", "superadmin@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAELROyAKrIL7HRmHQWoQNCGE+2bvngDD88MWxSALRI77CtFC08OCQwRVpqZLHmGD/1g==", null, false, "6912654b-099e-43be-b370-728e9bb31f5c", null, false, "SuperAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomFeatures");

            migrationBuilder.DropTable(
                name: "RoomSettings");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoomMappings",
                table: "UserRoomMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomConfigurations",
                table: "RoomConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8337047c-3f3f-425d-a635-5b67dde80afa");

            migrationBuilder.RenameTable(
                name: "UserRoomMappings",
                newName: "UserRoomMapping");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "RoomConfigurations",
                newName: "RoomConfiguration");

            migrationBuilder.RenameTable(
                name: "Meetings",
                newName: "Meeting");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoomMapping",
                table: "UserRoomMapping",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomConfiguration",
                table: "RoomConfiguration",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "RoomFeature",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeature", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomSetting",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FeatureID = table.Column<Guid>(type: "char(36)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RoomID = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantID = table.Column<Guid>(type: "char(36)", nullable: false),
                    Value = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSetting", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantID", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b40e0174-d628-4a98-a44e-db4b06254f49", 0, "7f438979-1076-4b82-bbd8-e1a7ef382ea9", "superadmin@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEENXuBXk2QOHGaW+9hzbk5+kDlM7HJ3caBYOrw8JRPiFBY07S80ACoAYiaxEH7sGsw==", null, false, "861305fd-f32c-4254-bb55-c98b1cc18bf3", null, false, "SuperAdmin" });
        }
    }
}
