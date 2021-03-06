using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TPS.Models;
using TPS.Services;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using TPS.Helpers;

namespace TPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _iUserService;
        private IConfiguration _config;
        private JwtService _jwtService;
        public UserController(IUserService userService, IConfiguration config, JwtService jwtService)
        {
            _iUserService = userService;
            _config = config;
            _jwtService = jwtService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Login([FromBody] Authenticate authenticate)
        {
            var user = _iUserService.GetByUsername(authenticate.Username);
            if (user == null) return BadRequest(new { message = "Invalid crdentials" });

                //var password = BCrypt.Net.BCrypt.HashPassword(authenticate.Password);
                if (!BCrypt.Net.BCrypt.Verify(authenticate.Password, user.Password))
                {
                    return BadRequest(new { message="Invalid crdentials" });
                }
            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                Secure = true,
                SameSite = SameSiteMode.None
            });
            return Ok(user);

            //return Ok(new
            //{
            //    message = "success"
            //});

        }
        [HttpGet("account")]
        public IActionResult GetUserAccount()
        {
            try
            {
                var userId = GetUserId();

                var useraccount = _iUserService.GetAccount(userId);
                if (useraccount != null)
                {

                    return Ok(useraccount);
                }
                return Ok("you do not have an account");
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }
        public string GetUserId()
        {
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);

            string userId = token.Issuer;
            return userId;
        }
    }
}