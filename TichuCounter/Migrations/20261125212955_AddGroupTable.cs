using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TichuCounter.Migrations;

/// <inheritdoc />
public partial class _20261125212955_AddGroupTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "group",
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
                table.PrimaryKey("PK_group", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "player_in_group",
            columns: table => new
            {
                id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                player_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                group_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                table.PrimaryKey("PK_player_in_group", x => x.id);
                table.ForeignKey(
                    name: "FK_player_in_group_group_group_id",
                    column: x => x.group_id,
                    principalTable: "group",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_player_in_group_player_player_id",
                    column: x => x.player_id,
                    principalTable: "player",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_player_in_group_group_id",
            table: "player_in_group",
            column: "group_id");

        migrationBuilder.CreateIndex(
            name: "IX_player_in_group_player_id",
            table: "player_in_group",
            column: "player_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "player_in_group");

        migrationBuilder.DropTable(
            name: "group");
    }
}
