using Core.Entity;

namespace Core.Specification
{
    public class  ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(ProductSpecParams productParams)
                                                    : base(x =>(string.IsNullOrEmpty(productParams.search)|| x.Name.ToLower().Contains(productParams.search)) &&
                                                     (!productParams.brandId.HasValue || x.ProductBrandId == productParams.brandId) &&
                                                    (!productParams.typeId.HasValue || x.ProductTypeId == productParams.typeId))
        {
            AddIncludes(x=> x.ProductType);
            AddIncludes(x=> x.ProductBrand);
            AddOrderBy(x=> x.Name);
            ApplyPaging(productParams.pageSize*(productParams.PageIndex-1),productParams.pageSize);

            if(!string.IsNullOrEmpty(productParams.sort))
            {
                switch(productParams.sort)
                {
                    case "PriceAsc":
                        AddOrderBy(p=>p.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDescending(p=>p.Price);
                        break;
                   default:
                        AddOrderBy(p=>p.Name);
                        break;
                }
            }

        }

        public ProductWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x=> x.ProductType);
            AddIncludes(x=> x.ProductBrand);
        }


    }
}