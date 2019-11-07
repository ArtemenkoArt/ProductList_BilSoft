using Ninject;
using Ninject.Web.Common;
using ProductList.Dal.Context;
using ProductList.Dal.Repositories.Contracts;
using ProductList.Dal.Repositories.Implementations;

namespace ProductList.Dal.Infrastructure.NinjectConfig
{
    public static class DalKernel
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.Bind<IProductListContext>().To<ProductListContext>();
            kernel.Bind<IProductRepository>().To<ProductRepository>().InRequestScope();
            kernel.Bind<IProductCategoryRepository>().To<ProductCategoryRepository>().InRequestScope();
        }
    }
}
