using System.ComponentModel.DataAnnotations.Schema;

namespace TichuCounter.Model.Entity;

[Table("seat")]
public class SeatEntity : BaseEntity
{
    [Column("tichu_result", TypeName = "VARCHAR(19)")]
    public ETichuResult TichuResult { get; set; }
}
