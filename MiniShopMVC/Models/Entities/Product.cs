namespace MiniShopMVC.Models.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public ICollection<ProductOrder> ProductOrders { get; set; } = null!;
}