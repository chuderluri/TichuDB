using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TichuCounter.Migrations;

/// <inheritdoc />
public partial class _20261125205218_AddSeatTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "team_a_seat_1_id",
            table: "round",
            type: "char(36)",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            collation: "ascii_general_ci");

        migrationBuilder.AddColumn<Guid>(
            name: "team_a_seat_2_id",
            table: "round",
            type: "char(36)",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            collation: "ascii_general_ci");

        migrationBuilder.AddColumn<Guid>(
            name: "team_b_seat_1_id",
            table: "round",
            type: "char(36)",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            collation: "ascii_general_ci");

        migrationBuilder.AddColumn<Guid>(
            name: "team_b_seat_2_id",
            table: "round",
            type: "char(36)",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            collation: "ascii_general_ci");

        migrationBuilder.CreateTable(
            name: "seat",
            columns: table => new
            {
                id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                tichu_result = table.Column<string>(type: "VARCHAR(19)", nullable: false)
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
                table.PrimaryKey("PK_seat", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_round_team_a_seat_1_id",
            table: "round",
            column: "team_a_seat_1_id");

        migrationBuilder.CreateIndex(
            name: "IX_round_team_a_seat_2_id",
            table: "round",
            column: "team_a_seat_2_id");

        migrationBuilder.CreateIndex(
            name: "IX_round_team_b_seat_1_id",
            table: "round",
            column: "team_b_seat_1_id");

        migrationBuilder.CreateIndex(
            name: "IX_round_team_b_seat_2_id",
            table: "round",
            column: "team_b_seat_2_id");

        migrationBuilder.AddForeignKey(
            name: "FK_round_seat_team_a_seat_1_id",
            table: "round",
            column: "team_a_seat_1_id",
            principalTable: "seat",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_round_seat_team_a_seat_2_id",
            table: "round",
            column: "team_a_seat_2_id",
            principalTable: "seat",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_round_seat_team_b_seat_1_id",
            table: "round",
            column: "team_b_seat_1_id",
            principalTable: "seat",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_round_seat_team_b_seat_2_id",
            table: "round",
            column: "team_b_seat_2_id",
            principalTable: "seat",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_round_seat_team_a_seat_1_id",
            table: "round");

        migrationBuilder.DropForeignKey(
            name: "FK_round_seat_team_a_seat_2_id",
            table: "round");

        migrationBuilder.DropForeignKey(
            name: "FK_round_seat_team_b_seat_1_id",
            table: "round");

        migrationBuilder.DropForeignKey(
            name: "FK_round_seat_team_b_seat_2_id",
            table: "round");

        migrationBuilder.DropTable(
            name: "seat");

        migrationBuilder.DropIndex(
            name: "IX_round_team_a_seat_1_id",
            table: "round");

        migrationBuilder.DropIndex(
            name: "IX_round_team_a_seat_2_id",
            table: "round");

        migrationBuilder.DropIndex(
            name: "IX_round_team_b_seat_1_id",
            table: "round");

        migrationBuilder.DropIndex(
            name: "IX_round_team_b_seat_2_id",
            table: "round");

        migrationBuilder.DropColumn(
            name: "team_a_seat_1_id",
            table: "round");

        migrationBuilder.DropColumn(
            name: "team_a_seat_2_id",
            table: "round");

        migrationBuilder.DropColumn(
            name: "team_b_seat_1_id",
            table: "round");

        migrationBuilder.DropColumn(
            name: "team_b_seat_2_id",
            table: "round");
    }
}
