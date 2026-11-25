using System.ComponentModel.DataAnnotations.Schema;

namespace TichuCounter.Model.Entity;

[Table("player_in_group")]
public class PlayerInGroupEntity : BaseEntity
{
    [Column("player_id")]
    public Guid PlayerId { get; set; }

    [ForeignKey(nameof(PlayerId))]
    public PlayerEntity? Player { get; set; }

    [Column("group_id")]
    public Guid GroupId { get; set; }

    [ForeignKey(nameof(GroupId))]
    public GroupEntity? Group { get; set; }
}
