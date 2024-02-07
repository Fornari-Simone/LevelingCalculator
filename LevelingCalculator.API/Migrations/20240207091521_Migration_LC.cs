using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevelingCalculator.API.Migrations
{
    /// <inheritdoc />
    public partial class Migration_LC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CharRes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Elite = table.Column<int>(type: "int", nullable: false),
                    IDChar = table.Column<int>(type: "int", nullable: false),
                    IDRes1 = table.Column<int>(type: "int", nullable: false),
                    IDRes2 = table.Column<int>(type: "int", nullable: false),
                    IDRes3 = table.Column<int>(type: "int", nullable: false),
                    ResN1 = table.Column<int>(type: "int", nullable: false),
                    ResN2 = table.Column<int>(type: "int", nullable: false),
                    ResN3 = table.Column<int>(type: "int", nullable: false),
                    LMD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharRes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CharRes_Character_IDChar",
                        column: x => x.IDChar,
                        principalTable: "Character",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharRes_Resource_IDRes3",
                        column: x => x.IDRes3,
                        principalTable: "Resource",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharRes_IDChar",
                table: "CharRes",
                column: "IDChar");

            migrationBuilder.CreateIndex(
                name: "IX_CharRes_IDRes3",
                table: "CharRes",
                column: "IDRes3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharRes");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
