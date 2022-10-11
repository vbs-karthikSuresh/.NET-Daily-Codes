using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class IntitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kar_students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Marks = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kar_students", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "kar_students",
                columns: new[] { "ID", "Marks", "Name" },
                values: new object[] { 1, 30f, "Karthik" });

            migrationBuilder.InsertData(
                table: "kar_students",
                columns: new[] { "ID", "Marks", "Name" },
                values: new object[] { 2, 50f, "Suresh" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kar_students");
        }
    }
}
