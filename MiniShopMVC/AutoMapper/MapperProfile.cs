using AutoMapper;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;

namespace MiniShopMVC.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CategoryAddViewModel, Category>();
        CreateMap<ProductAddViewModel, Product>();
        CreateMap<CategoryUpdateViewModel, Category>();
        CreateMap<ProductUpdateViewModel, Product>();
    }
}