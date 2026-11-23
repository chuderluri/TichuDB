using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TichuCounter.Migrations;

/// <inheritdoc />
public partial class _20261122120150_AddGameTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "game",
            columns: table => new
            {
                id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                point_target = table.Column<int>(type: "int", nullable: false),
                is_finished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                started_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                finished_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
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
                table.PrimaryKey("PK_game", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "game");
    }
}
