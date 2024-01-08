using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamePeekrReviewManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class userRoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleValue",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleValue",
                table: "User");
        }
    }
}
