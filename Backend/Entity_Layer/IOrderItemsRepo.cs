using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Entities;

namespace Entity_Layer
{
    public interface IOrderItemsRepo
    {
        public OrderItem AddOrderItem(OrderItem item);

        public List<OrderItem> GetOrderItems();

        public OrderItem GetOrderItembyID(int id);
    }
}
