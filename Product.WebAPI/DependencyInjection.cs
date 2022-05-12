using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.NetCore.Base.Abstract;
using Recipe.NetCore.Base.Interface;
using Recipe.NetCore.Infrastructure;
using Product.Core.DbContext;
using Product.Core.Interface.Repository;
using Product.Repository;
using Product.Service;
using Product.Core.Interface.Service;

namespace Product.API
{
    public class DependencyInjection
    {
        public void Map(IServiceCollection services, IConfiguration configuration)
        {
            #region Base          
            services.AddHttpContextAccessor();
            services.AddScoped<IRequestInfo<ProductDbContext>, RequestInfo<ProductDbContext>>();
            services.AddScoped<IUnitOfWork, UnitOfWork<ProductDbContext>>();
            services.AddScoped(typeof(IService), typeof(Recipe.NetCore.Base.Generic.Service));
            #endregion

            #region User Management
 
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            #endregion

        }
    }
}
