using Microsoft.EntityFrameworkCore.Migrations;

namespace Garages_Recruit_1271.Migrations
{
    public partial class SeedUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Mail", "Name", "Password", "Phone", "Status" },
                values: new object[] { 2, "ddddeee", "eee@gmail.com", "gggg", "ddddfff", 33333, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
