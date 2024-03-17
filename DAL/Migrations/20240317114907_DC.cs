using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchScholars_ResearchScholars_ResearchScholarId",
                table: "ResearchScholars");

            migrationBuilder.DropIndex(
                name: "IX_ResearchScholars_ResearchScholarId",
                table: "ResearchScholars");

            migrationBuilder.DropColumn(
                name: "ResearchScholarId",
                table: "ResearchScholars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResearchScholarId",
                table: "ResearchScholars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchScholars_ResearchScholarId",
                table: "ResearchScholars",
                column: "ResearchScholarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchScholars_ResearchScholars_ResearchScholarId",
                table: "ResearchScholars",
                column: "ResearchScholarId",
                principalTable: "ResearchScholars",
                principalColumn: "Id");
        }
    }
}
