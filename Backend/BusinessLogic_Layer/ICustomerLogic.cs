using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace BusinessLogic_Layer
{
    public interface ICustomerLogic
    {
        public List<CustomerDetails_Model> GetCustomers();

        public CustomerDetails_Model AddCustomers(CustomerDetails_Model customerDetail);

        public CustomerDetails_Model UpdateCustomers(CustomerDetails_Model customerDetail);

        public CustomerDetails_Model GetCustomerbyID(string id);
    }
}
