using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _userRepository;
        public TokenController(IConfiguration configuration, IUsuarioRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/login")]
        public IActionResult Post([FromBody]LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
               if(!getUserValid(loginViewModel))
                    return Unauthorized();
                
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, loginViewModel.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken
                (
                    issuer: _configuration["Issuer"],
                    audience: _configuration["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SigningKey"])),
                         SecurityAlgorithms.HmacSha256)
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest();
        }

        private bool getUserValid(LoginViewModel loginViewModel)
        {
            return _userRepository.IsValidUser(loginViewModel);
        }
    }
}