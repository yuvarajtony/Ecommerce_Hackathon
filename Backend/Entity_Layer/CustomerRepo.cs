using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Entities;

namespace Entity_Layer
{
    public class CustomerRepo: ICustomerRepo
    {
        EcommerceDbContext _context = new EcommerceDbContext();

        public CustomerDetail AddCustomers(CustomerDetail customerDetail)
        {
            _context.CustomerDetails.Add(customerDetail);
            _context.SaveChanges();
            return customerDetail;
        }

        public CustomerDetail GetCustomerbyID(string id)
        {
            return _context.CustomerDetails.FirstOrDefault(x => x.CustomerEmail == id);
        }

        public List<CustomerDetail> GetCustomers()
        {
            return _context.CustomerDetails.ToList();
        }

        public CustomerDetail UpdateCustomers(CustomerDetail customerDetail)
        {
            _context.CustomerDetails.Update(customerDetail);
            _context.SaveChanges();
            return customerDetail;
        }
    }
}
