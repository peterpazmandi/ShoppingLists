using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.DTOs;
using Microsoft.AspNetCore.Identity;
using API.Entities;
using API.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<LoginUserDto>> Register(RegisterUserDto registerDto)
        {
            if (await UserExists(registerDto.Username))
            {
                return BadRequest("Username is already taken!");
            }

            var user = _mapper.Map<AppUser>(registerDto);
            
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new LoginUserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName.ToLower().Equals(loginDto.Username.ToLower()));

            if (user is null)
            {
                return BadRequest("Invalid username!");
            }

            var result = await _signInManager  .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("The username or the password is incorrect!");
            }

            return new LoginUserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user)
            };
        }





        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }
    }
}