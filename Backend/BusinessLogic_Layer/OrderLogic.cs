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
    public class OrderLogic : IOrderLogic
    {
        IOrderRepo _repo = new OrderRepo();

        public Order_Model AddOrder(Order_Model order)
        {
            return Mapper.EMOrdMapper(_repo.AddOrder(Mapper.MEOrdMapper(order)));
        }

        public void DeleteOrder(int id)
        {
            _repo.DeleteOrder(id);
        }

        public List<Order_Model> GetOrderbyCustomerID(string customerID)
        {
            List<Order_Model> ord = new List<Order_Model>();

            foreach(var i in _repo.GetOrderbyCustomerID(customerID))
            {
                ord.Add(Mapper.EMOrdMapper(i));
            }

            return ord;
        }

        public Order_Model GetOrderById(int id)
        {
            return Mapper.EMOrdMapper(_repo.GetOrderById(id));
        }

        public List<Order_Model> GetOrders()
        {
            List<Order_Model> ord = new List<Order_Model>();

            foreach(var i in _repo.GetOrders())
            {
                ord.Add(Mapper.EMOrdMapper(i));
            }

            return ord;
        }
    }
}
