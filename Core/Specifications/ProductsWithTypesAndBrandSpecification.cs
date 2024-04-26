using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandSpecification:BaseSpecifcation<Product>
    {
        public ProductsWithTypesAndBrandSpecification()
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
        public ProductsWithTypesAndBrandSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
    }
}