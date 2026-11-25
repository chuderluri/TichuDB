using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TichuCounter.Migrations;

/// <inheritdoc />
public partial class _20261125210645_AddPlayerTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "player_id",
            table: "seat",
            type: "char(36)",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            collation: "ascii_general_ci");

        migrationBuilder.CreateTable(
            name: "player",
            columns: table => new
            {
                id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
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
                table.PrimaryKey("PK_player", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_seat_player_id",
            table: "seat",
            column: "player_id");

        migrationBuilder.AddForeignKey(
            name: "FK_seat_player_player_id",
            table: "seat",
            column: "player_id",
            principalTable: "player",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_seat_player_player_id",
            table: "seat");

        migrationBuilder.DropTable(
            name: "player");

        migrationBuilder.DropIndex(
            name: "IX_seat_player_id",
            table: "seat");

        migrationBuilder.DropColumn(
            name: "player_id",
            table: "seat");
    }
}
