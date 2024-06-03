using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Storage : BaseModel
{
    [InverseProperty("Storages")]
    public virtual List<Product>? Products { get; set; } = new();
}