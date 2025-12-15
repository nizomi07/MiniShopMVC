using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniShopMVC.Data;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;
using MiniShopMVC.Models.Filters;

namespace MiniShopMVC.Services;

public class ProductService(DataContext context, IMapper mapper) : IProductService
{
    public async Task<List<Product>> GetProductsAsync(ProductFilter f)
    {
        var query = context.Products
            .AsQueryable();

        if (f.Id.HasValue) query = query.Where(x => x.Id == f.Id.Value);
        if(f.CategoryId.HasValue) query = query.Where(x => x.CategoryId == f.CategoryId.Value);
        if (!string.IsNullOrEmpty(f.Name)) query = query.Where(x => x.Name.Contains(f.Name));
         
        return await query.ToListAsync();
    }

    public async Task<Product> AddProductAsync(ProductAddViewModel model)
    {
        var product = mapper.Map<Product>(model);
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteProductAsync(int id)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null)
        {
            return null!;
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(ProductUpdateViewModel model)
    {
        var product = mapper.Map<Product>(model);
        context.Products.Update(product);
        await context.SaveChangesAsync();
        return product;
    }
}