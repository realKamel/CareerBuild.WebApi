using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.AppData.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToTrackEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverUrl",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverUrl",
                table: "Tracks");
        }
    }
}
