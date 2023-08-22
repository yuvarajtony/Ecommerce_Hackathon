using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Entities;

namespace Entity_Layer
{
    public class OrderRepo : IOrderRepo
    {
        EcommerceDbContext _context = new EcommerceDbContext();
        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void DeleteOrder(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.OrderId == id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public List<Order> GetOrderbyCustomerID(string customerID)
        {
            return _context.Orders.Where(x => x.CustomerEmail.Contains(customerID)).ToList(); 
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.OrderId == id);
        }

        public List<Order> GetOrders()
        {
           return _context.Orders.ToList();
        }
    }
}
