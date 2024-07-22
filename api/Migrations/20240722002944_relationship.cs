using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79e8e703-124a-47c4-b943-35fdae6cd369");

            migrationBuilder.AlterColumn<string>(
                name: "DiasSemana",
                table: "activities",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "activities",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de55cc8b-a848-4bab-b4f1-e49fabf7437e", null, "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_activities_AppUserId",
                table: "activities",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_activities_AspNetUsers_AppUserId",
                table: "activities",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activities_AspNetUsers_AppUserId",
                table: "activities");

            migrationBuilder.DropIndex(
                name: "IX_activities_AppUserId",
                table: "activities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de55cc8b-a848-4bab-b4f1-e49fabf7437e");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "activities");

            migrationBuilder.UpdateData(
                table: "activities",
                keyColumn: "DiasSemana",
                keyValue: null,
                column: "DiasSemana",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "DiasSemana",
                table: "activities",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "79e8e703-124a-47c4-b943-35fdae6cd369", null, "User", "USER" });
        }
    }
}
