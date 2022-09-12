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

            query = Spec.Includes.Aggregate(query,(current,includes)=> current.Include(includes));

            return query;

        }
    }
}