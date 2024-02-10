using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevelingCalculator.API.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Craftable",
                table: "Resource",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Own",
                table: "Resource",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TransactionalOutboxes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tabella = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Messaggio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionalOutboxes", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionalOutboxes");

            migrationBuilder.DropColumn(
                name: "Craftable",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "Own",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Character");
        }
    }
}
