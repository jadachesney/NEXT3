using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEXTGroup3.Migrations
{
    /// <inheritdoc />
    public partial class resultmodelattributefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentPoints",
                table: "Result",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RolePoints",
                table: "Result",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentPoints",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "RolePoints",
                table: "Result");
        }
    }
}
