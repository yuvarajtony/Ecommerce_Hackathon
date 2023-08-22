using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace BusinessLogic_Layer
{
    public interface IOrderLogic
    {
        public List<Order_Model> GetOrders();

        public Order_Model GetOrderById(int id);

        public Order_Model AddOrder(Order_Model order);

        public List<Order_Model> GetOrderbyCustomerID(string customerID);

        public void DeleteOrder(int id);
    }
}
