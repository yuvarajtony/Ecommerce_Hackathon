using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Entities;

namespace Entity_Layer
{
    public class ProductRepo : IProductRepo
    {
        EcommerceDbContext _context = new EcommerceDbContext();
        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges(); 
            return product;
        }

        public List<Product> GetProduct()
        {
            return _context.Products.ToList();
        }

        public Product GetProductbyID(int productID)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == productID);
        }
    }
}
