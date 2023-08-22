using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer;
using Entity_Layer.Entities;
using Model_Layer;

namespace BusinessLogic_Layer
{
    public class OrderItemsLogic : IOrderItemsLogic
    {
        IOrderItemsRepo _repo = new OrderItemsRepo();
        public OrderItem_Model AddOrderItem(OrderItem_Model item)
        {
            return Mapper.EMOrdItmMapper(_repo.AddOrderItem(Mapper.MEOrdItmMapper(item)));
        }

        public List<OrderItem_Model> GetOrderItems()
        {
            List<OrderItem_Model> orditm = new List<OrderItem_Model>();

            foreach(var i in _repo.GetOrderItems())
            {
                orditm.Add(Mapper.EMOrdItmMapper(i));
            }

            return orditm;
        }
        public OrderItem_Model GetOrderItembyID(int id)
        {
            return Mapper.EMOrdItmMapper(_repo.GetOrderItembyID(id));
        }

        public OrderItem_Model GetOrderItembyOrderID(int id)
        {
            return Mapper.EMOrdItmMapper(_repo.GetOrderItembyOrderID(id));
        }
    }
}
