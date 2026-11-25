using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TichuCounter.Model.Entity;

[Table("player")]
public class PlayerEntity : BaseEntity
{
    [Column("name")]
    [MaxLength(255)]
    public string Name { get; set; } = "";

    public List<PlayerInGroupEntity>? PlayerInGroups { get; set; }
    public List<GroupEntity>? Groups { get; set; }
}
