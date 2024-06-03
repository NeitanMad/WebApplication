using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class ProductsStorage
{
    [ForeignKey("Product")]
    public virtual int? ProductId { get; set; }
    public virtual Product? Product { get; set; }

    [ForeignKey("Storage")]
    public virtual int? StorageId { get; set; }
    public virtual Storage? Storage { get; set; }

}