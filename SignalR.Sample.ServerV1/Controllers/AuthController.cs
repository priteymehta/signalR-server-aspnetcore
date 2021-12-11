using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//add an action to exchange an identity cookie for a token
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
//using SignalRChat.Data;

namespace SignalR.Sample.ServerV1.Controllers
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthController : Controller
    {
        //private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration config;

        //public AuthController(SignInManager<ApplicationUser> signInManager, IConfiguration config)
        //{
        //    this.signInManager = signInManager;
        //    this.config = config;
        //}
        
        [HttpGet("api/token")]
        [Authorize]
        public IActionResult GetToken()
        {
            return Ok(GenerateToken(User.Identity.Name));
        }

        private string GenerateToken(string userId)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(config["JwtKey"]));

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("signalrdemo", "signalrdemo", claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}