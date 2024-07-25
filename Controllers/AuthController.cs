﻿using EventWhiz.Models.DTO;
using EventWhiz.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventWhiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase 
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        //POST : /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);
            if(identityResult.Succeeded)
            {
                //Add roles to this User
                if(registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                    if(identityResult.Succeeded)
                    {
                        return Ok("User Registered! Please try to Login Now.");
                    }
                }
            }
            return BadRequest("Something went wrong!");
        }

        //POST: /api/Auth/Login
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.UserName);
            if(user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if(checkPasswordResult)
                {
                    //get roles for this user
                    var roles = await userManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                        //createToken
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                }
            }
            return BadRequest("UserName or Password incorrect!");
        }
    }
}
