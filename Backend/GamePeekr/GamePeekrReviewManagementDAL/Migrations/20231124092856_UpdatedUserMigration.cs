using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamePeekrReviewManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "apiKey",
                table: "User",
                newName: "ApiKey");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "ApiKey",
                table: "User",
                newName: "apiKey");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id");
        }
    }
}
