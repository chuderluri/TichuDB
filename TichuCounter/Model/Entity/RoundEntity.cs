using System.ComponentModel.DataAnnotations.Schema;

namespace TichuCounter.Model.Entity;

[Table("round")]
public class RoundEntity : BaseEntity
{
    [Column("round_number")]
    public int RoundNumber { get; set; }

    [Column("double_win_result", TypeName = "VARCHAR(5)")]
    public EDoubleWinResult DoubleWinResult { get; set; }

    [Column("pints_team_a")]
    public int PointsTeamA { get; set; }

    [Column("pints_team_b")]
    public int PointsTeamB { get; set; }

    [Column("timestamp", TypeName = "datetime")]
    public DateTimeOffset Timestamp { get; set; }

    [Column("game_id")]
    public Guid GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public GameEntity? GameEntity { get; set; }
}
