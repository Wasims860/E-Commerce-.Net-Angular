using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specifications;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity>GetQuery(IQueryable<TEntity> inputQuery,ISpecifcations<TEntity> spec){
            var query = inputQuery;//inputQuery is like Products
            if(spec.Criteria!=null)
            {
                query = query.Where(spec.Criteria);//spec.Criteria should look like :x=>x.Id==id
            }
            query=spec.Includes.Aggregate(query, (current,include)=>current.Include(include));
            return query;
        }
    }
}