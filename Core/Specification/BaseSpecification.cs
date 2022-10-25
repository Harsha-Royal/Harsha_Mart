using System.Linq.Expressions; 

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {

        public Expression<Func<T,bool>> Criteria {get;}

         public  List<Expression<Func<T,object>>> Includes {get;} = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> orderBy {get; private set;}

        public Expression<Func<T, object>> orderByDescending {get; private set;}

        public int Take {get; private set;}
        public int Skip {get; private set;}
        public bool IsPageEnabled {get; private set;}

        public BaseSpecification()
         {

         }

         public BaseSpecification(Expression<Func<T,bool>> criteria)
         {
            Criteria = criteria;
         }

        protected void AddIncludes(Expression<Func<T,object>> include)
        {
            Includes.Add(include);
        }  

        protected void AddOrderBy(Expression<Func<T,object>> orderbyExpression)
        {
            orderBy = orderbyExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T,object>> orderByDescExpression)
        {
            orderByDescending = orderByDescExpression;
        }

        protected void ApplyPaging(int skip,int take)
        {
            Skip = skip;
            Take = take;
            IsPageEnabled = true;

        }

    }
}