using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Entities;

namespace Entity_Layer
{
    public class OrderItemsRepo : IOrderItemsRepo
    {
        EcommerceDbContext _context = new EcommerceDbContext();
        public OrderItem AddOrderItem(OrderItem item)
        {
            _context.OrderItems.Add(item);
            _context.SaveChanges();
            return item;
        }

        public OrderItem GetOrderItembyID(int id)
        {
            return _context.OrderItems.FirstOrDefault(x => x.OrderItemId == id);   
        }

        public List<OrderItem> GetOrderItems()
        {
            return _context.OrderItems.ToList();
        }

        public OrderItem GetOrderItembyOrderID(int id)
        {
            return _context.OrderItems.FirstOrDefault(x => x.OrderId == id);
        }
    }
}
