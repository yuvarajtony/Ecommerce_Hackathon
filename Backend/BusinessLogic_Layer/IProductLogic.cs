using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace BusinessLogic_Layer
{
    public interface IProductLogic
    {
        public Product_Model AddProduct(Product_Model product);

        public List<Product_Model> GetProduct();

        public Product_Model GetProductbyID(int productID);
    }
}
