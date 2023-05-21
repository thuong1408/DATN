using DemoCore.Interfaces.Infracstructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsRepository _productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet("Filter")]
        //[Authorize(Roles = "admin")]
        public IActionResult GetSearchAndPaging(int? pageSize, int? pageNumber, string? productFilter)
        {
            try
            {
                //Lấy kết quả từ Course Repository
                var result = _productsRepository.GetSearchAndPaging(pageSize, pageNumber, productFilter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ProductID")]
        
        public IActionResult GetProductByProductID(int ProductID)
        {
            try
            {
                //Lấy kết quả từ Course Repository
                var result = _productsRepository.GetProductByProductID(ProductID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
