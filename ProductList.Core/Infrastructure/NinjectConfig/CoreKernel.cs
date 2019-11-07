using Ninject;
using Ninject.Web.Common;
using ProductList.Core.Services.Contracts;
using ProductList.Core.Services.Implementations;
using ProductList.Dal.Infrastructure.NinjectConfig;

namespace ProductList.Core.Infrastructure.NinjectConfig
{
    public static class CoreKernel
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.Bind<IProductService>().To<ProductService>().InRequestScope();
            kernel.Bind<IProductCategoryService>().To<ProductCategoryService>().InRequestScope();
            DalKernel.Initialize(kernel);
        }
    }
}
