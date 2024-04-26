using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecifcation<T> : ISpecifcations<T>
    {
        public BaseSpecifcation()
        {
            
        }
        public BaseSpecifcation(Expression<Func<T, bool>> criteria)
        {
            Criteria= criteria;
        }
        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes  {get;} = new List<Expression<Func<T,object>>>();

        //We Can call This Function From any class that inherited From BaseSpecifcation class
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}