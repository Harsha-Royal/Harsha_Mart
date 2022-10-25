
using API.Dtos;
using API.Errors;
using API.Helper;
using AutoMapper;
using Core.Entity;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo,IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }





        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDtos>>> GetProducts(ProductSpecParams productParams)                                                                   
        {
            var spec = new ProductWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _productsRepo.CountAsync(countSpec);
            var products = await _productsRepo.ListAsync(spec); 


            var data = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDtos>>(products);
            return Ok(new Pagination<ProductToReturnDtos>(productParams.PageIndex,productParams.pageSize,totalItems,data));
         }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDtos>> GetProduct(int id)
        {
              var spec = new ProductWithTypesAndBrandsSpecification(id);
              var product= await _productsRepo.GetEntityWithSpec(spec);
                if(product == null)
                {
                    return NotFound(new ApiResponse(404));

                }

              return _mapper.Map<Product , ProductToReturnDtos>(product);
            
        }

        [HttpGet("brands")]
         public async Task<ActionResult<Product>> GetProductBrands(int id)
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }


         public async Task<ActionResult<Product>> GetProductTypes(int id)
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

    }
    
}