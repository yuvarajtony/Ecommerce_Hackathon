using Model_Layer;
using EL = Entity_Layer.Entities;

namespace BusinessLogic_Layer
{
    public class Mapper
    {
        // Model to Entity

        public static EL.CustomerDetail MECusMapper(CustomerDetails_Model model)
        {
            return new EL.CustomerDetail()
            {
                CustomerEmail = model.CustomerEmail,
                CustomerName = model.CustomerName,
                CustomerMobileNo = model.CustomerMobileNo,
                CustomerAddressLine1 = model.CustomerAddressLine1,
                CustomerAddressLine2 = model.CustomerAddressLine2,
                CustomerCity = model.CustomerCity,
            };
        }

        public static EL.Order MEOrdMapper(Order_Model model)
        {
            return new EL.Order()
            {
                OrderId = model.OrderId,
                CustomerEmail = model.CustomerEmail,
                OrderDate = model.OrderDate,
                DeliveryDate = model.DeliveryDate,
                ShipmentCity = model.ShipmentCity,
                ShipmentStatus = model.ShipmentStatus,
            };
        }

        public static EL.Product MEProMapper(Product_Model model)
        {
            return new EL.Product()
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Price = model.Price,
            };
        }

        public static EL.OrderItem MEOrdItmMapper(OrderItem_Model model)
        {
            return new EL.OrderItem()
            {
                OrderItemId = model.OrderItemId,
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                TotalPrice = model.TotalPrice,
            };
        }


        // Entity to Model

        public static CustomerDetails_Model EMCusMapper(EL.CustomerDetail entity)
        {
            return new CustomerDetails_Model()
            {
                CustomerEmail = entity.CustomerEmail,
                CustomerName = entity.CustomerName,
                CustomerMobileNo = entity.CustomerMobileNo,
                CustomerAddressLine1 = entity.CustomerAddressLine1,
                CustomerAddressLine2 = entity.CustomerAddressLine2,
                CustomerCity = entity.CustomerCity,
            };
        }

        public static Order_Model EMOrdMapper(EL.Order entity)
        {
            return new Order_Model()
            {
                OrderId = entity.OrderId,
                CustomerEmail = entity.CustomerEmail,
                OrderDate = entity.OrderDate,
                DeliveryDate = entity.DeliveryDate,
                ShipmentCity = entity.ShipmentCity,
                ShipmentStatus = entity.ShipmentStatus,
            };
        }

        public static Product_Model EMProMapper(EL.Product entity)
        {
            return new Product_Model()
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                Price = entity.Price,
            };
        }

        public static OrderItem_Model EMOrdItmMapper(EL.OrderItem entity)
        {
            return new OrderItem_Model()
            {
                OrderItemId = entity.OrderItemId,
                OrderId = entity.OrderId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                TotalPrice = entity.TotalPrice,
            };
        }
    }
}