using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wipster.Refactoring.Application.Dtos;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Persistence;

namespace Wipster.Refactoring.Application
{
    public class ProductsService
    {
        public IList<Product> GetProductsList()
        {
            using (var db = new NorthwindDbContext())
            {
                var result = db.Products.ToList();
                return result;
            }
        }

        public List<Product> GetProductsStartsWith(string name)
        {
            // The ORM can generate SQL needed to filter. Unless there is a perfomance bottleneck, ths is not necessary
            using (var db = new NorthwindDbContext())
            {
                //inline SQL will expose the application to SQL injection Attacks
                var sql = "SELECT * FROM Products WHERE ProductName LIKE '" + name + "%'";
                var result = db.Products.FromSqlRaw(sql).ToList();
                return result;
            }
        }

        public Product GetProduct(int productId)
        {
            // If we had the repository pattern, we would not touch the DB context. 
            using (var db = new NorthwindDbContext())
            {
                var result = db.Products
                    .Where(p => p.ProductId == productId)
                    .FirstOrDefault();
                return result;
            }
        }

        public Product CreateProduct(ProductRequest request)
        {
            //Problem with anemic models is there are no conditions to enforce conditions under which the object should exist. this method is useless
            return new Product();
        }

        public Product UpdateProduct(int id, ProductRequest request)
        { //Problem with anemic models is there are no conditions to enforce conditions under which the object should exist. this method is useless
            return new Product();
        }

        public void DeleteProduct(int productId)
        {
// Perhaps we have a cascade operation that will get rid of orphaned objects. If we do not have flesh for a method, we should not have it bones. We only define methods we need  
        }
    }
}
