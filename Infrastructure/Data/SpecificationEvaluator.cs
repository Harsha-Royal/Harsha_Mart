using Core.Entity;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> Spec)
        {

            var query = inputQuery;

            if(Spec.Criteria!=null)
            {
                query = query.Where(Spec.Criteria);
            }

            if(Spec.orderBy != null)
            {
                query = query.OrderBy(Spec.orderBy);
            }

            if(Spec.orderByDescending != null)
            {
                query = query.OrderByDescending(Spec.orderByDescending);
            }

            if(Spec.IsPageEnabled)
            {
                query = query.Skip(Spec.Skip).Take(Spec.Take);
            }
            
            query = Spec.Includes.Aggregate(query,(current,includes)=> current.Include(includes));

            return query;

        }
    }
}