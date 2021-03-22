using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FuelLog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FuelLog.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("api/getUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(User);

            if(id == null)
            {
                throw new ArgumentNullException("User not exists.");
            }
            var user = await _userManager.FindByIdAsync(id);
            return Json(new
            {
                Name = user.Email,
                Id = user.Id,
                Type = User.Identity.AuthenticationType
            });
        }


        [HttpPost("api/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var identityUser = new IdentityUser { UserName = user.Email, Email = user.Email };
            var result = await _userManager.CreateAsync(identityUser, user.Password);

            if (result.Errors.Count() > 0)
            {
                return new JsonResult(result.Errors);       
            }

            await _signInManager.SignInAsync(identityUser, isPersistent: false);

            return new JsonResult(user);
        }


        [HttpGet("api/logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return new JsonResult("User is logged out");
        }


        [HttpPost("api/login")]
        public async Task<IActionResult> Login([FromBody] Login user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            IActionResult response = Unauthorized();

            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

            var tokenString = GenerateJSONWebToken(user);
            response = Ok(new { token = tokenString });
            if (!result.Succeeded)
            {
                return new JsonResult("Invalid login attempt");
            }
            return response;
        }


        private string GenerateJSONWebToken(Login user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);   
        }


    }
}
