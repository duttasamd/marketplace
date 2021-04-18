using Marketplace.Service;
using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IdentityModel.Tokens.Jwt;

namespace Marketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IUserService userService;

        public AuthenticationController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("test")]
        public String Test()
        {
            return "Api service running.";
        }

        [HttpPut("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserModel user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName))
            {
                return BadRequest("Empty mandatory fields.");
            }

            ApplicationUser applicationUser = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.Email
            };

            try
            {
                bool isSuccessful = await userService.RegisterUserAsync(applicationUser, user.Password);

                if (isSuccessful)
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            try
            {
                JwtSecurityToken token = await userService.Login(user.Email, user.Password);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
