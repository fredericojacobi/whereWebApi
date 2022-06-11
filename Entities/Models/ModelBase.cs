using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class ModelBase
{
    [Key]
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

}