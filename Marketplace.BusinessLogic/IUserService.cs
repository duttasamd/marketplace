using Marketplace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Service
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(ApplicationUser user, string password);
        Task<JwtSecurityToken> Login(string email, string password);
    }

    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> userManager;

        private IConfiguration configuration;

        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        async Task<bool> IUserService.RegisterUserAsync(ApplicationUser user, string password)
        { 
            var result = await userManager.CreateAsync(user, password);

            if(result.Succeeded)
            {
                return true;
            }

            throw new Exception("User not added : " + string.Join(",", result.Errors.Select(x => x.Description).ToList()));
        }

        async Task<JwtSecurityToken> IUserService.Login(string email, string password)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);

            if(user != null)
            {
                bool isAuthententic = await userManager.CheckPasswordAsync(user, password);
                if(isAuthententic)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id)
                    };

                    var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Secret"]));

                    var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials : new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256)
                    );

                    return token;
                }
            }

            throw new Exception("Incorrect Email or Password.");
        }
    }
}
