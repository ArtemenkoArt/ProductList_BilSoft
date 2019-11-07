using AutoMapper;
using ProductList.Core.Models;
using ProductList.Dal.Entities;

namespace ProductList.Core.Infrastructure.MapperConfig
{
    public class CoreMapperProfile : Profile
    {
        public CoreMapperProfile()
        {
            CreateMap<Product, ProductCore>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryCore>().ReverseMap();
        }
    }
}
