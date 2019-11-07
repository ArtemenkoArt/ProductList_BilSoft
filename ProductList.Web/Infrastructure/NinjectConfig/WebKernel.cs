using AutoMapper;
using Ninject;
using ProductList.Core.Infrastructure.NinjectConfig;
using ProductList.Web.Infrastructure.MapperConfig;

namespace ProductList.Web.Infrastructure.NinjectConfig
{
    public static class WebKernel
    {
        public static void Initialize(IKernel kernel)
        {
            //Services
            var config = new MapperConfiguration(cfg =>
            {
                WebMapperConfig.Initialize(cfg);
            });

            kernel.Bind<IMapper>().ToConstructor(c => new Mapper(config)).InSingletonScope();

            CoreKernel.Initialize(kernel);
        }
    }
}