using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "QualificationName", "Timestamp" },
                values: new object[] { 1, "Test1", null });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "QualificationName", "Timestamp" },
                values: new object[] { 2, "Test2", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumns: new[] { "Id", "Timestamp" },
                keyValues: new object[] { 1, null });

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumns: new[] { "Id", "Timestamp" },
                keyValues: new object[] { 2, null });
        }
    }
}
