using Cw8.Models.DTOs;
using Cw8.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cw8.Controllers
{
    [Route("accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountDbService _accountDbService;

        public AccountsController(IAccountDbService accountDbService)
        {
            _accountDbService = accountDbService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountDTO account)
        {
            try
            {
                await _accountDbService.Register(account);
                return Ok("Added new account to database");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountDTO account)
        {
            try
            {
                return Ok(await _accountDbService.Login(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("updatetoken")]
        public async Task<IActionResult> UpdateToken(RefreshTokenDTO refreshToken)
        {
            try
            {
                return Ok(await _accountDbService.GetNewAccessToken(refreshToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
