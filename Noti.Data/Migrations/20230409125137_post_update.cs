using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noti.Data.Migrations
{
    /// <inheritdoc />
    public partial class post_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostContent",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostContent",
                table: "Posts");
        }
    }
}
