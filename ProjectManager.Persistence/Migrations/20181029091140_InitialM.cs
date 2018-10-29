using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Persistence.Migrations
{
    public partial class InitialM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "QualificationName", "Timestamp" },
                values: new object[] { 3, "Test3", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumns: new[] { "Id", "Timestamp" },
                keyValues: new object[] { 3, null });
        }
    }
}
