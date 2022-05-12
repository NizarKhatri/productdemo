using Product.Core.Entity;
using Recipe.NetCore.Base.Interface;
using System;

namespace Product.Core.Interface.Repository
{
    public interface IProductRepository : IAuditableRepository<Products, Int32>
    {

    }
}

