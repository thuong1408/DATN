using DemoCore.Entities;
using DemoCore.Exceptions;
using DemoCore.Interfaces.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace DemoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        IAuthenticationService _authenticationService;
        IAuthenticationRepository _authenticationRepository;

        public AccountController(IAuthenticationService authenticationService,IAuthenticationRepository authenticationRepository)
        {
            _authenticationService = authenticationService;
            _authenticationRepository=authenticationRepository;
        }
        
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Account account)
        {
            try
            {
                var result = _authenticationService.LoginService(account);
                var refreshToken = GenerateRefreshToken();
                SetRefreshToken(refreshToken);
                return Ok(result);
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = account,
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Tạo ra RefeshToken
        /// </summary>
        /// <returns></returns>
        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                TokenString = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                TokenExpires = DateTime.Now.AddDays(15),
                TokenCreated = DateTime.Now
            };
            return refreshToken;
        }

        /// <summary>
        /// Thiết lập refreshtoken
        /// </summary>
        /// <param name="newRefreshToken"></param>
        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.TokenExpires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.TokenString, cookieOptions);
        }
    }
}
