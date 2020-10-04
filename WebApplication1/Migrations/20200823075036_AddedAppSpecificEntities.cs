using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceApp.Migrations
{
    public partial class AddedAppSpecificEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "431b1c76-9ff6-427f-bccf-61e9d47906ac");

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    RoomID = table.Column<Guid>(nullable: false),
                    TenantID = table.Column<Guid>(nullable: false),
                    ServerID = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NumberOfParticipants = table.Column<int>(nullable: false),
                    AccessCode = table.Column<string>(nullable: true),
                    LastSessionAt = table.Column<DateTime>(nullable: false),
                    LastSessionBy = table.Column<string>(nullable: true),
                    ServerID = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    MoodifiedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomConfiguration",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantID = table.Column<string>(nullable: true),
                    FeatureID = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomConfiguration", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeature",
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
                    table.PrimaryKey("PK_RoomFeature", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomSetting",
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
                    table.PrimaryKey("PK_RoomSetting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoomMapping",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    RoomID = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoomMapping", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantID", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b40e0174-d628-4a98-a44e-db4b06254f49", 0, "7f438979-1076-4b82-bbd8-e1a7ef382ea9", "superadmin@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEENXuBXk2QOHGaW+9hzbk5+kDlM7HJ3caBYOrw8JRPiFBY07S80ACoAYiaxEH7sGsw==", null, false, "861305fd-f32c-4254-bb55-c98b1cc18bf3", null, false, "SuperAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomConfiguration");

            migrationBuilder.DropTable(
                name: "RoomFeature");

            migrationBuilder.DropTable(
                name: "RoomSetting");

            migrationBuilder.DropTable(
                name: "UserRoomMapping");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b40e0174-d628-4a98-a44e-db4b06254f49");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantID", "TwoFactorEnabled", "UserName" },
                values: new object[] { "431b1c76-9ff6-427f-bccf-61e9d47906ac", 0, "1c9baec4-2ac8-43a7-a0f0-91e3cb2ff166", "superadmin@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGfwX/fDI6ScLmgJVILHZutJ8ly76ytpSUaHsTuBsGqdRxlxzlSJcmCc490S2ibIbA==", null, false, "8d09afc3-1c52-4e6b-9740-86dd269e8a42", null, false, "SuperAdmin" });
        }
    }
}
