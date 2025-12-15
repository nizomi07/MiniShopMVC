using MiniShopMVC.Models.Entities;

namespace MiniShopMVC.Models.Filters;

public class ProductFilter
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    
    public long? Id { get; set; }
    public string? Name { get; set; }
    public int? CategoryId { get; set; }
}