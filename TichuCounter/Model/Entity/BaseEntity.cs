using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TichuCounter.Model.Entity;

public class BaseEntity
{
    [Column("id")]
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Column("created")]
    public DateTimeOffset Created { get; set; }

    [Column("created_by")]
    [MaxLength(255)]
    public string CreatedBy { get; set; } = "";

    [Column("updated")]
    public DateTimeOffset Updated { get; set; }

    [Column("updated_by")]
    [MaxLength(255)]
    public string UpdatedBy { get; set; } = "";

    [ConcurrencyCheck]
    [Column("row_version")]
    public long RowVersion { get; set; }
}
