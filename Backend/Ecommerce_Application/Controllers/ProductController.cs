using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic_Layer;
using Model_Layer;

namespace Ecommerce_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductLogic _logic = new ProductLogic();

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] Product_Model product_Model)
        {
            try
            {
                return Ok(_logic.AddProduct(product_Model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct()
        {
            try
            {
                if (_logic.GetProduct() != null)
                {
                    return Ok(_logic.GetProduct());
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

        [HttpGet("GetProductbyID/{id}")]
        public IActionResult GetProductbyID(int id)
        {

            try
            {
                var data = _logic.GetProductbyID(id);

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
