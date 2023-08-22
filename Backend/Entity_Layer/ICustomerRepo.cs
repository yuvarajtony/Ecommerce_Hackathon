using Entity_Layer.Entities;

namespace Entity_Layer
{
    public interface ICustomerRepo
    {
        public List<CustomerDetail> GetCustomers();

        public CustomerDetail AddCustomers(CustomerDetail customerDetail);

        public CustomerDetail UpdateCustomers(CustomerDetail customerDetail);

        public CustomerDetail GetCustomerbyID(string id);
    }
}