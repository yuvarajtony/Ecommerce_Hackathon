using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Entities;

namespace Entity_Layer
{
    public interface IProductRepo
    {
        public Product AddProduct(Product product);

        public List<Product> GetProduct();

        public Product GetProductbyID(int productID);
    }
}
