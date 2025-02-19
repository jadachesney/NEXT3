using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEXTGroup3.Migrations
{
    /// <inheritdoc />
    public partial class Questions_and_Results_and_Candidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RangeQuestionId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RangeQuestionId1",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_RangeQuestionId",
                table: "Department",
                column: "RangeQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_RangeQuestionId1",
                table: "Department",
                column: "RangeQuestionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_RangeQuestion_RangeQuestionId",
                table: "Department",
                column: "RangeQuestionId",
                principalTable: "RangeQuestion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_RangeQuestion_RangeQuestionId1",
                table: "Department",
                column: "RangeQuestionId1",
                principalTable: "RangeQuestion",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_RangeQuestion_RangeQuestionId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_RangeQuestion_RangeQuestionId1",
                table: "Department");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "RangeQuestion");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Department_RangeQuestionId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_RangeQuestionId1",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "RangeQuestionId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "RangeQuestionId1",
                table: "Department");
        }
    }
}
