using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPS.Helpers;
using TPS.Models;
using TPS.Services;

namespace TPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _iaccountService;
        private JwtService _jwtService;
        public AccountController(IAccountService iAccountService, JwtService jwtService)
        {
            _iaccountService = iAccountService;
            _jwtService = jwtService;
        }
        [HttpPost("Transfer")]
        public IActionResult TransferMoney([FromBody]UpdateAccBalModel model)
        {
            try { 
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);

            string userId = token.Issuer;
            var account = _iaccountService.GetAccount(userId);
            if (account.AccBalance < model.Amount)
            {
                return BadRequest(new { message = "You have insufficient funds to make this transaction" });
            }
            var acc = _iaccountService.UpdateAccountBalance(account.Id, model.Amount);
            return Ok(acc);
            }
             catch (Exception)
            {
                return Unauthorized();
            }
        }
        [HttpPost("Withdraw")]
        public IActionResult WithdrawMoney([FromBody]WithdrawalModel model)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                string userId = token.Issuer;
                var account = _iaccountService.GetAccount(userId);
                var atm = _iaccountService.GetATM(model.AtmName);
                if (atm.AtmBalance < model.Amount)
                {
                    return BadRequest(new { message = "ATM cannot disperse the amount at the moment" });
                }
                    if (account.AccBalance < model.Amount) { 
                    return BadRequest(new { message = "insufficient funds to make this transaction" });
                }
                var acc = _iaccountService.UpdateAccountBalance(account.Id, model.Amount);
                _iaccountService.UpdateAtmBalance(atm.Id, model.Amount);

                return Ok(acc);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
        public TUser GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new TUser
                {
                    Id= userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Name = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                };
            }
            return null;
        }
    }
}