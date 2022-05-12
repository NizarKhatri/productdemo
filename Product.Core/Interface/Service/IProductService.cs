using Recipe.NetCore.Base.Abstract;
using Recipe.NetCore.Base.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.NetCore.Attribute;
using Recipe.NetCore.Enum;
using Product.Core.Interface.Repository;
using Product.Core.Dto;
using Product.Core.Entity;

namespace Product.Core.Interface.Service
{
	public interface IProductService : IService<IProductRepository, Products, ProductDto, Int32>
	{
        Task<DataTransferObject<List<ProductByStatusDto>>> GetProductCountByStatus(int? Status);
        Task<DataTransferObject<ProductDto>> ChangeProductStatus(ProductDto productDto);
        Task<DataTransferObject<ProductDto>> SellProduct(int productId);
    }
}
