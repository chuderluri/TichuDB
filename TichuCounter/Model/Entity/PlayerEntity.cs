using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TichuCounter.Model.Entity;

[Table("player")]
public class PlayerEntity : BaseEntity
{
    [Column("name")]
    [MaxLength(255)]
    public string Name { get; set; } = "";
}
