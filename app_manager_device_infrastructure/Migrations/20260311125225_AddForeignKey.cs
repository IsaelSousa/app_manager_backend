using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_manager_device_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppManagerId",
                schema: "AppManager",
                table: "Devices",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_AppManagerId",
                schema: "AppManager",
                table: "Devices",
                column: "AppManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Apps_AppManagerId",
                schema: "AppManager",
                table: "Devices",
                column: "AppManagerId",
                principalSchema: "AppManager",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Apps_AppManagerId",
                schema: "AppManager",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_AppManagerId",
                schema: "AppManager",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "AppManagerId",
                schema: "AppManager",
                table: "Devices");
        }
    }
}
