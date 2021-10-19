using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemeImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextCoordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorizontalPoint = table.Column<int>(type: "int", nullable: false),
                    VerticalPoint = table.Column<int>(type: "int", nullable: false),
                    MemeImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextCoordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextCoordinates_MemeImages_MemeImageId",
                        column: x => x.MemeImageId,
                        principalTable: "MemeImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextCoordinates_MemeImageId",
                table: "TextCoordinates",
                column: "MemeImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextCoordinates");

            migrationBuilder.DropTable(
                name: "MemeImages");
        }
    }
}
