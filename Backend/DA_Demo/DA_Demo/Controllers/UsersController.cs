using DemoCore.Interfaces.Infracstructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class UsersController : ControllerBase
    {
        IUsersRepository _repository;
        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GellAllUsers()
        {
            try
            {
                var users = _repository.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
