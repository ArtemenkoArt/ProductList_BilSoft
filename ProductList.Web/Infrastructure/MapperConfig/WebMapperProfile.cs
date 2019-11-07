using AutoMapper;
using ProductList.Core.Models;
using ProductList.Web.Models;

namespace ProductList.Web.Infrastructure.MapperConfig
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<ProductCore, ProductViewModel>().ReverseMap();
            CreateMap<ProductCategoryCore, ProductCategoryViewModel>().ReverseMap();
        }
    }
}