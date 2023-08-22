using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic_Layer;
using Model_Layer;

namespace Ecommerce_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderLogic _logic = new OrderLogic();

        [HttpPost("AddOrder")]
        public IActionResult AddOrder([FromBody] Order_Model order_Model)
        {
            try
            {
                return Ok(_logic.AddOrder(order_Model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrder")]
        public IActionResult GetOrder()
        {
            try
            {
                if (_logic.GetOrders() != null)
                {
                    return Ok(_logic.GetOrders());
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

        [HttpGet("GetorderbyID/{id}")]
        public IActionResult GetOrderbyID([FromRoute] int id)
        {
            try
            {
                var data = _logic.GetOrderById(id);

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

        [HttpGet("GetOrderbyCustomer/{id}")]
        public IActionResult GetorderbyCustomer([FromRoute] string id)
        {
            try
            {
                return Ok(_logic.GetOrderbyCustomerID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteOrder/{id}")]
        public IActionResult DeleteOrder([FromRoute] int id)
        {
            try
            {
                _logic.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
