using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic_Layer;
using Model_Layer;

namespace Ecommerce_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailController : ControllerBase
    {
        ICustomerLogic _logic = new CustomerLogic();


        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody] CustomerDetails_Model customerDetails_Model)
        {
            try
            {
                return Ok(_logic.AddCustomers(customerDetails_Model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetCustomers")]
        public IActionResult GetCustomers()
        {
            try
            {
                if (_logic.GetCustomers() != null)
                {
                    return Ok(_logic.GetCustomers());
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerbyID/{id}")]

        public IActionResult GetCusbyID([FromRoute] string id) 
        {
            try
            {
                var data = _logic.GetCustomerbyID(id);
                
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCustomer")]
        
        public IActionResult UpdateCustomer([FromBody] CustomerDetails_Model customerDetails)
        {
            try
            {
                var data = _logic.UpdateCustomers(customerDetails);
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
