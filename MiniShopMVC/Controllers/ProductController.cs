using Microsoft.AspNetCore.Mvc;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;
using MiniShopMVC.Models.Filters;
using MiniShopMVC.Services;

namespace MiniShopMVC.Controllers;

public class ProductController(IProductService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Products =  await service.GetProductsAsync(new ProductFilter());
        return View();
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] ProductAddViewModel model)
    {
        await service.AddProductAsync(model);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await service.DeleteProductAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(ProductUpdateViewModel model)
    {
        ViewBag.UpdateProduct = model;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm] ProductUpdateViewModel model)
    {
        await service.UpdateProductAsync(model);
        return RedirectToAction("Index");
    }
}