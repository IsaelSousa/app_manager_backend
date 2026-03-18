using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_manager_device_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveShouldNotify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShouldUpdate",
                schema: "AppManager",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ShouldUpdate",
                schema: "AppManager",
                table: "Apps");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShouldUpdate",
                schema: "AppManager",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShouldUpdate",
                schema: "AppManager",
                table: "Apps",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
