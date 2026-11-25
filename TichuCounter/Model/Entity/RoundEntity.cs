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

    [Column("team_a_seat_1_id")]
    public Guid TeamASeat1Id { get; set; }

    [ForeignKey(nameof(TeamASeat1Id))]
    public SeatEntity? TeamASeat1 { get; set; }

    [Column("team_a_seat_2_id")]
    public Guid TeamASeat2Id { get; set; }

    [ForeignKey(nameof(TeamASeat2Id))]
    public SeatEntity? TeamASeat2 { get; set; }

    [Column("team_b_seat_1_id")]
    public Guid TeamBSeat1Id { get; set; }

    [ForeignKey(nameof(TeamBSeat1Id))]
    public SeatEntity? TeamBSeat1 { get; set; }

    [Column("team_b_seat_2_id")]
    public Guid TeamBSeat2Id { get; set; }

    [ForeignKey(nameof(TeamBSeat2Id))]
    public SeatEntity? TeamBSeat2 { get; set; }
}
