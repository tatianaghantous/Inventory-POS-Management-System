using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLoginID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "LoginId",
                keyValue: 1L);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "LoginId", "BackupNumber", "BranchID", "Email", "HasPermission", "HashedPassword", "LastConnection", "Password", "Username" },
                values: new object[] { 4L, null, null, null, 1L, null, null, "123", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "LoginId",
                keyValue: 4L);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "LoginId", "BackupNumber", "BranchID", "Email", "HasPermission", "HashedPassword", "LastConnection", "Password", "Username" },
                values: new object[] { 1L, null, null, null, 1L, null, null, "123", "admin" });
        }
    }
}
