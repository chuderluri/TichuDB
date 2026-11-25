using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TichuCounter.Migrations;

/// <inheritdoc />
public partial class _20261125203532_AddRoundTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "round",
            columns: table => new
            {
                id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                round_number = table.Column<int>(type: "int", nullable: false),
                double_win_result = table.Column<string>(type: "VARCHAR(5)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                pints_team_a = table.Column<int>(type: "int", nullable: false),
                pints_team_b = table.Column<int>(type: "int", nullable: false),
                timestamp = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                game_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                created = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                created_by = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                updated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                updated_by = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                row_version = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_round", x => x.id);
                table.ForeignKey(
                    name: "FK_round_game_game_id",
                    column: x => x.game_id,
                    principalTable: "game",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_round_game_id",
            table: "round",
            column: "game_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "round");
    }
}
