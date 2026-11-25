using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TichuCounter.Model.Entity;

[Table("game")]
public class GameEntity : BaseEntity
{
    [Column("name")]
    [MaxLength(255)]
    public string Name { get; set; } = "";

    [Column("point_target")]
    public int PointTarget { get; set; }

    [Column("is_finished")]
    public bool IsFinished { get; set; }

    [Column("started_at", TypeName = "datetime")]
    public DateTimeOffset StartedAt { get; set; }

    [Column("finished_at", TypeName = "datetime")]
    public DateTimeOffset? FinishedAt { get; set; }

    public List<RoundEntity>? Rounds { get; set; }
}
