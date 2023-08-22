using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Entities;

namespace Entity_Layer
{
    public interface IOrderRepo
    {
        public List<Order> GetOrders();

        public Order GetOrderById(int id);

        public Order AddOrder(Order order);

        public List<Order> GetOrderbyCustomerID(string customerID);

        public void DeleteOrder(int id);


    }
}
