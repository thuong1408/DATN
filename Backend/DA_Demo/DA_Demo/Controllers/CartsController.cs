using DemoCore.Interfaces.Infracstructure;
using DemoInfracstructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DA_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        ICartRepository _cartRepository;
        public CartsController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        [HttpGet("Filter")]
        public IActionResult GetSearchAndPaging(string UserID, int? pageSize, int? pageNumber, string? keyFilter)
        {
            try
            {
                //Lấy kết quả từ Course Repository
                var result = _cartRepository.GetSearchAndPagingUserID(UserID, pageSize, pageNumber, keyFilter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Cart")]
        public IActionResult UpdateCart(string UserID, int ProductID, int soluong)
        {
            try
            {
                //Lấy kết quả từ Course Repository
                var result = _cartRepository.UpdateCartUserID(UserID, ProductID, soluong);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
