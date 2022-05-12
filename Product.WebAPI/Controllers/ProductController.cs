using Microsoft.AspNetCore.Mvc;
using Product.Core.Dto;
using Product.Core.Interface.Service;
using System.Threading.Tasks;
using Recipe.NetCore.Infrastructure;
using System.Collections.Generic;

namespace Product.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        [Route("getProductCount/{status?}")]
        public async Task<IActionResult> GetProductCountByStatus(int? Status)
        {
            return JsonResponse(await _ProductService.GetProductCountByStatus(Status));
        }

        [HttpPut]
        [Route("changeStatus")]
        public async Task<IActionResult> ChangeProductStatus(ProductDto productDto)
        {
            return JsonResponse(await _ProductService.ChangeProductStatus(productDto));
        }

        [HttpPost]
        [Route("sellProduct/{productId}")]
        public async Task<IActionResult> SellProduct(int productId)
        {
            return JsonResponse(await _ProductService.SellProduct(productId));
        }


    }
}
