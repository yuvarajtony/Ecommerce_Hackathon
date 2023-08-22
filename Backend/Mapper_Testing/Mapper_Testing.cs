using BusinessLogic_Layer;
using Model_Layer;
using entity = Entity_Layer.Entities;


namespace Mapper_Testing
{
    [TestFixture]
    public class Tests
    {

        // Entity to Model mapper testing

        [Test]
        public void EMCustomer()
        {
            entity.CustomerDetail customer = new entity.CustomerDetail();
            var model = Mapper.EMCusMapper(customer);
            Assert.AreEqual(model.GetType(), typeof(CustomerDetails_Model));
        }


        [Test]
        public void EMOrder()
        {
            entity.Order order = new entity.Order();
            var model = Mapper.EMOrdMapper(order);
            Assert.AreEqual(model.GetType(), typeof(Order_Model));
        }


        [Test]
        public void EMProduct()
        {
            entity.Product product = new entity.Product();
            var model = Mapper.EMProMapper(product);
            Assert.AreEqual(model.GetType(), typeof(Product_Model));
        }


        [Test]
        public void EMOrderItem()
        {
            entity.OrderItem item = new entity.OrderItem();
            var model = Mapper.EMOrdItmMapper(item);
            Assert.AreEqual(model.GetType(), typeof(OrderItem_Model));
        }


        // Model to Entity mapper testing

        [Test]
        public void MECustomer()
        {
            CustomerDetails_Model customer = new CustomerDetails_Model();
            var entity = Mapper.MECusMapper(customer);
            Assert.AreEqual(entity.GetType(), typeof(entity.CustomerDetail));
        }


        [Test]
        public void MEOrder()
        {
            Order_Model order = new Order_Model();
            var entity = Mapper.MEOrdMapper(order);
            Assert.AreEqual(entity.GetType(), typeof(entity.Order));
        }


        [Test]
        public void MEProduct()
        {
            Product_Model product_Model = new Product_Model();
            var entity = Mapper.MEProMapper(product_Model);
            Assert.AreEqual(entity.GetType(), typeof(entity.Product));
        }


        [Test]
        public void MEOrderItem()
        {
            OrderItem_Model orderItem_Model = new OrderItem_Model();
            var entity = Mapper.MEOrdItmMapper(orderItem_Model);
            Assert.AreEqual(entity.GetType(), typeof(entity.OrderItem));
        }
    }
}