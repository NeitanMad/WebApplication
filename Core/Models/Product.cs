using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Product : BaseModel
{
    public int Cost { get; set; }
    [ForeignKey("Category")]
    public virtual int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public virtual List<Storage> Storages { get; set; } = new();
}