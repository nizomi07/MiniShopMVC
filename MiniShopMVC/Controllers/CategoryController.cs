using Microsoft.AspNetCore.Mvc;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Filters;
using MiniShopMVC.Services;

namespace MiniShopMVC.Controllers;

public class CategoryController(ICategoryService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Categories = await service.GetCategoriesAsync(new CategoryFilter());
        return View();
    }
    
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CategoryAddViewModel model)
    {
        await service.AddCategoryAsync(model);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await service.DeleteCategoryAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(CategoryUpdateViewModel model)
    {
        ViewBag.UpdateCategory = model;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SaveUpdate([FromForm] CategoryUpdateViewModel model)
    {
        await service.UpdateCategoryAsync(model);
        return RedirectToAction("Index");
    }
}