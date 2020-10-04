using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceApp.Migrations
{
    public partial class MultitenancySupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8337047c-3f3f-425d-a635-5b67dde80afa");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FeatureID",
                table: "RoomSettings");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "RoomSettings");

            migrationBuilder.DropColumn(
                name: "MoodifiedBy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "FeatureID",
                table: "RoomConfigurations");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "RoomConfigurations");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "Meetings");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomFeatureID",
                table: "RoomSettings",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomFeatureID",
                table: "RoomConfigurations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantID", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11dd775b-c357-4eb9-ad9f-178fe178ffd4", 0, "3e2d5bdc-6a3f-4b47-a75b-524dae9fe75e", "superadmin@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEEWJAaWCtkMUNeylp5KR67SJxAiOkZ7vd/W/mGTfZT7ZTiQbocjsYsGIFtKlSXURRw==", null, false, "41227168-c054-4783-95e9-de83005c8339", null, false, "SuperAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoomMappings_RoomID",
                table: "UserRoomMappings",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoomMappings_UserID",
                table: "UserRoomMappings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSettings_RoomFeatureID",
                table: "RoomSettings",
                column: "RoomFeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSettings_RoomID",
                table: "RoomSettings",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomConfigurations_RoomFeatureID",
                table: "RoomConfigurations",
                column: "RoomFeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_RoomID",
                table: "Meetings",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Rooms_RoomID",
                table: "Meetings",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomConfigurations_RoomFeatures_RoomFeatureID",
                table: "RoomConfigurations",
                column: "RoomFeatureID",
                principalTable: "RoomFeatures",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_RoomFeatures_RoomFeatureID",
                table: "RoomSettings",
                column: "RoomFeatureID",
                principalTable: "RoomFeatures",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Rooms_RoomID",
                table: "RoomSettings",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoomMappings_Rooms_RoomID",
                table: "UserRoomMappings",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoomMappings_User_UserID",
                table: "UserRoomMappings",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Rooms_RoomID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomConfigurations_RoomFeatures_RoomFeatureID",
                table: "RoomConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_RoomFeatures_RoomFeatureID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Rooms_RoomID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoomMappings_Rooms_RoomID",
                table: "UserRoomMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoomMappings_User_UserID",
                table: "UserRoomMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoomMappings_RoomID",
                table: "UserRoomMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoomMappings_UserID",
                table: "UserRoomMappings");

            migrationBuilder.DropIndex(
                name: "IX_RoomSettings_RoomFeatureID",
                table: "RoomSettings");

            migrationBuilder.DropIndex(
                name: "IX_RoomSettings_RoomID",
                table: "RoomSettings");

            migrationBuilder.DropIndex(
                name: "IX_RoomConfigurations_RoomFeatureID",
                table: "RoomConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_RoomID",
                table: "Meetings");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11dd775b-c357-4eb9-ad9f-178fe178ffd4");

            migrationBuilder.DropColumn(
                name: "RoomFeatureID",
                table: "RoomSettings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomFeatureID",
                table: "RoomConfigurations");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantID",
                table: "User",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureID",
                table: "RoomSettings",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantID",
                table: "RoomSettings",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "MoodifiedBy",
                table: "Rooms",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantID",
                table: "Rooms",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureID",
                table: "RoomConfigurations",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "TenantID",
                table: "RoomConfigurations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantID",
                table: "Meetings",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantID", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8337047c-3f3f-425d-a635-5b67dde80afa", 0, "f1657ed6-c651-46a5-b63d-5169e72a3dfb", "superadmin@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAELROyAKrIL7HRmHQWoQNCGE+2bvngDD88MWxSALRI77CtFC08OCQwRVpqZLHmGD/1g==", null, false, "6912654b-099e-43be-b370-728e9bb31f5c", null, false, "SuperAdmin" });
        }
    }
}
