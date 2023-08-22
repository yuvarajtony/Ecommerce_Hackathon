using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Entities;
using Model_Layer;

namespace BusinessLogic_Layer
{
    public interface IOrderItemsLogic
    {
        public OrderItem_Model AddOrderItem(OrderItem_Model item);

        public List<OrderItem_Model> GetOrderItems();

        public OrderItem_Model GetOrderItembyID(int id);
        public OrderItem_Model GetOrderItembyOrderID(int id);

    }
}
