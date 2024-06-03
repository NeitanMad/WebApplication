using Core.Models;

namespace WebApplication1.Models;

public class ProductResponse : BaseModel
{
    public int Cost { get; set; }
    public virtual int CategoryId { get; set; }
    public virtual string? Category { get; set; }
}