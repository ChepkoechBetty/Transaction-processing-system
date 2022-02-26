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
            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (authenticate.Password!=user.Password)
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }
            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "success"
            });

        }
        [HttpGet("account")]
        public IActionResult GetUserAccount()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                string userId =token.Issuer;

                var useraccount = _iUserService.GetAccount(userId);

                return Ok(useraccount);
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
    }
}