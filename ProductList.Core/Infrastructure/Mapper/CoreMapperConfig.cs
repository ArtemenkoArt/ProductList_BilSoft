using AutoMapper;

namespace ProductList.Core.Infrastructure.Mapper
{
    public static class CoreMapperConfig
    {
        public static void Initialize(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<CoreMapperProfile>();
        }
    }
}
