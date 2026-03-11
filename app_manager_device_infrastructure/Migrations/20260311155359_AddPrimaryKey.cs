using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_manager_device_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                schema: "AppManager",
                table: "Devices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                schema: "AppManager",
                table: "Devices",
                columns: new[] { "Id", "Device" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                schema: "AppManager",
                table: "Devices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                schema: "AppManager",
                table: "Devices",
                column: "Id");
        }
    }
}
