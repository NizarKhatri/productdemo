using AutoMapper;
using Product.Core.Dto;
using Product.Core.Entity;
using Product.Core.Interface.Repository;
using Product.Core.Interface.Service;
using Recipe.NetCore.Base.Abstract;
using Recipe.NetCore.Base.Generic;
using Recipe.NetCore.Base.Interface;
using Recipe.NetCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Service
{
    public class ProductService : Service<IProductRepository, Products, ProductDto, Int32>, IProductService
    {
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper)
        {
            _mapper = mapper;
        }

        public async Task<DataTransferObject<List<ProductByStatusDto>>> GetProductCountByStatus(int? Status)
        {
            var dataTransferObject = new DataTransferObject<List<ProductByStatusDto>>()
            {
                Result = new List<ProductByStatusDto>()
            };

            try
            {
                var ProductList = (await Repository.Query(x => (Status == null) || x.Status == Status).SelectAsync()).GroupBy(y => y.Status).Select(s =>
                    new ProductByStatusDto
                    {
                        ProductStatus = ((ProductStatus)s.Key).ToString(),
                        Count = s.Count(q => q.Id > 0)
                    })
                .ToList();

                dataTransferObject.Result = ProductList;
            }
            catch (Exception ex)
            {
                dataTransferObject.HasErrors = true;
                dataTransferObject.Error = ex;
            }

            return dataTransferObject;
        }


        public async Task<DataTransferObject<ProductDto>> ChangeProductStatus(ProductDto productDto)
        {
            var dataTransferObject = new DataTransferObject<ProductDto>
            {
                Result = new ProductDto()
            };
            try
            {
                var product = (await Repository.Query(x => x.Id == productDto.Id).SelectAsync()).FirstOrDefault();

                if (product != null)
                {
                    product.Status = productDto.Status;
                    var result = await Repository.Update(product);
                    await SaveContext();
                    dataTransferObject.Result = _mapper.Map<Products, ProductDto>(result);
                    dataTransferObject.Result.StatusName = ((ProductStatus)productDto.Status).ToString();
                }
                else
                {
                    dataTransferObject.HasErrors = false;
                    dataTransferObject.Error = new Exception("Not a valid product");
                    dataTransferObject.Result = null;
                }

            }
            catch (Exception ex)
            {
                dataTransferObject.Error = ex;
                dataTransferObject.HasErrors = true;
            }
            return dataTransferObject;
        }


        public async Task<DataTransferObject<ProductDto>> SellProduct(int productId)
        {
            var dataTransferObject = new DataTransferObject<ProductDto>
            {
                Result = new ProductDto()
            };

            try
            {
                var ProductList = (await Repository.Query(x => x.Id == productId).SelectAsync()).FirstOrDefault();
                var ProductDto = _mapper.Map<Products, ProductDto>(ProductList);
                if (ProductList != null && ProductList.Status == (int)ProductStatus.Instock)
                {
                    ProductDto.Status = (int)ProductStatus.Sold;
                    var dto = await ChangeProductStatus(ProductDto);
                    dataTransferObject.Result = dto.Result;
                }
                else
                {
                    dataTransferObject.HasErrors = false;
                    dataTransferObject.Error = new Exception("The requested product has been out of stock or damaged");
                    dataTransferObject.Result = null;
                }
            }
            catch (Exception ex)
            {
                dataTransferObject.Error = ex;
                dataTransferObject.HasErrors = true;
            }

            return dataTransferObject;
        }
    }
}

