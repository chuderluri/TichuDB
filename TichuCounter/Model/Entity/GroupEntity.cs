using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TichuCounter.Model.Entity;

[Table("group")]
public class GroupEntity : BaseEntity
{
    [Column("name")]
    [MaxLength(255)]
    public string Name { get; set; } = "";

    public List<PlayerInGroupEntity>? PlayerInGroups { get; set; }
    public List<PlayerEntity>? Players { get; set; }
}
