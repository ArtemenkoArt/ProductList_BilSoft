using AutoMapper;
using ProductList.Core.Infrastructure.MapperConfig;

namespace ProductList.Web.Infrastructure.MapperConfig
{
    public static class WebMapperConfig
    {
        public static void Initialize(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<WebMapperProfile>();
            CoreMapperConfig.Initialize(cfg);
        }
    }
}