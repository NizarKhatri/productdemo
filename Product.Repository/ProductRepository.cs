using Product.Core.DbContext;
using Product.Core.Entity;
using Product.Core.Interface.Repository;
using Recipe.NetCore.Base.Generic;
using Recipe.NetCore.Base.Interface;
using System;

namespace Product.Repository
{
    public class ProductRepository : AuditableRepository<Products, Int32, ProductDbContext>, IProductRepository
    {
        public ProductRepository(IRequestInfo<ProductDbContext> requestInfo) : base(requestInfo)
        {
        }
    }
}

