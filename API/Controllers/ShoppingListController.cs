using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShoppingListController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingListController(UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateShoppingListDto shoppingListDto)
        {
            var users = await _unitOfWork.UserRepository.GetUsersByUsernamesAsync(shoppingListDto.MembersUsername);

            var shoppingList = _mapper.Map<ShoppingList>(shoppingListDto);
            shoppingList.Members = users.ToList();

            await _unitOfWork.ShoppingListRepository.CreateAsync(shoppingList);

            if (await _unitOfWork.CompleteAsync())
            {
                return Ok(shoppingList);
            }

            return BadRequest("Operation failed!");
        }
    }
}