using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceApp.Migrations
{
    public partial class TenantId_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11dd775b-c357-4eb9-ad9f-178fe178ffd4");

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "User",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "RoomSettings",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "Rooms",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "RoomConfigurations",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "Meetings",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantID", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a7ee5a32-517b-4895-9448-bb1dbdda9e76", 0, "ca59ba97-c04f-443a-a580-e53083b995fc", "superadmin@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOEW/1D+4trSDMfqKm/13OkkvJweexNdOPDTV9JBLYT91ZUS1+GrhrpMHD5S3qHs5A==", null, false, "96ea39be-fa00-4364-8ec8-6fff7b35f95e", null, false, "SuperAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7ee5a32-517b-4895-9448-bb1dbdda9e76");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "RoomSettings");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "RoomConfigurations");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Meetings");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantID", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11dd775b-c357-4eb9-ad9f-178fe178ffd4", 0, "3e2d5bdc-6a3f-4b47-a75b-524dae9fe75e", "superadmin@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEEWJAaWCtkMUNeylp5KR67SJxAiOkZ7vd/W/mGTfZT7ZTiQbocjsYsGIFtKlSXURRw==", null, false, "41227168-c054-4783-95e9-de83005c8339", null, false, "SuperAdmin" });
        }
    }
}
