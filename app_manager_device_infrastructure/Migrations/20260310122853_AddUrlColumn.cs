using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_manager_device_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "AppManager",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                schema: "AppManager",
                table: "Apps");
        }
    }
}
