using System.Linq.Expressions;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {

        public Expression<Func<T,bool>> Criteria {get;}

         public  List<Expression<Func<T,object>>> Includes {get;} = new List<Expression<Func<T, object>>>();

         public BaseSpecification()
         {

         }

         public BaseSpecification(Expression<Func<T,bool>> criteria)
         {
            Criteria = criteria;
         }

        public void AddIncludes(Expression<Func<T,object>> include)
        {
            Includes.Add(include);
        }  

    }
}