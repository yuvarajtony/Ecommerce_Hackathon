using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic_Layer;
using Model_Layer;

namespace Ecommerce_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        IOrderItemsLogic _logic = new OrderItemsLogic();

        [HttpPost("AddOderItems")]
        public IActionResult AddOrderItem([FromBody] OrderItem_Model orderItem_Model)
        {
            try
            {
                return Ok(_logic.AddOrderItem(orderItem_Model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrderItem")]
        public IActionResult GetOrderItem()
        {
            try
            {
                if (_logic.GetOrderItems() != null)
                {
                    return Ok(_logic.GetOrderItems());
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

        [HttpGet("GetOrderItembyID/{id}")]
        public IActionResult GetOrderItembyID([FromRoute] int id)
        {

            try
            {
                var data = _logic.GetOrderItembyID(id);

                if (data != null)
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


        [HttpGet("GetOrderItembyOrderID/{id}")]

        public IActionResult GetOrderitembyOrdID([FromRoute] int id)
        {
            try
            {
                var data = _logic.GetOrderItembyOrderID(id);

                if (data != null)
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

    }
}
