using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer;
using Entity_Layer.Entities;

namespace BusinessLogic_Layer
{
    public class ProductLogic : IProductLogic
    {
        IProductRepo _repo = new ProductRepo();

        public Product_Model AddProduct(Product_Model product)
        {
            return Mapper.EMProMapper(_repo.AddProduct(Mapper.MEProMapper(product)));
        }

        public List<Product_Model> GetProduct()
        {
            List<Product_Model> pro = new List<Product_Model>();

            foreach(var i in _repo.GetProduct())
            {
                pro.Add(Mapper.EMProMapper(i));
            }

            return pro;
        }

        public Product_Model GetProductbyID(int productID)
        {
            return Mapper.EMProMapper(_repo.GetProductbyID(productID));
        }
    }
}
