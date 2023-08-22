using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer;
using Entity_Layer.Entities;

namespace BusinessLogic_Layer
{
    public class CustomerLogic : ICustomerLogic
    {
        ICustomerRepo _repo = new CustomerRepo();
        
        public CustomerDetails_Model AddCustomers(CustomerDetails_Model customerDetail)
        {
            return Mapper.EMCusMapper(_repo.AddCustomers(Mapper.MECusMapper(customerDetail)));
        }

        public CustomerDetails_Model GetCustomerbyID(string id)
        {
            return Mapper.EMCusMapper(_repo.GetCustomerbyID(id));
        }

        public List<CustomerDetails_Model> GetCustomers()
        {
            List<CustomerDetails_Model> cus = new List<CustomerDetails_Model>();

            foreach(var i in _repo.GetCustomers())
            {
                cus.Add(Mapper.EMCusMapper(i));
            }

            return cus;
        }

        public CustomerDetails_Model UpdateCustomers(CustomerDetails_Model customerDetail)
        {
            return Mapper.EMCusMapper(_repo.UpdateCustomers(Mapper.MECusMapper(customerDetail)));
        }
    }
}
