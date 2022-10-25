using Core.Entity;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productSpecParams)
                                : base(x=> (!productSpecParams.brandId.HasValue || x.ProductBrandId == productSpecParams.brandId) &&
                                (!productSpecParams.typeId.HasValue || x.ProductTypeId == productSpecParams.typeId))
       {

       }

    }
}