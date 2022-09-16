using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
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
        [HttpGet("GetMyShoppingLists")]
        public async Task<IActionResult> GetMyShoppingLists()
        {
            var username = User.GetUsername();
            var lists = await _unitOfWork.ShoppingListRepository.GetByUsernameAsync(username);
            var _lists = _mapper.Map<List<ShoppingListDto>>(lists);
            return Ok(_lists);
        }


        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateShoppingListDto shoppingListDto)
        {
            var users = await _unitOfWork.UserRepository.GetUsersByUsernamesAsync(shoppingListDto.MembersUsername);

            var shoppingList = _mapper.Map<ShoppingList>(shoppingListDto);
            shoppingList.Members = users.ToList();

            shoppingList.Created = DateTime.Now;
            shoppingList.Modified = DateTime.Now;

            await _unitOfWork.ShoppingListRepository.CreateAsync(shoppingList);

            if (await _unitOfWork.CompleteAsync())
            {
                return Ok(shoppingList);
            }

            return BadRequest("Operation failed!");
        }

        [Authorize]
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateShoppingListDto shoppingListDto)
        {
            var currentShoppingList = await _unitOfWork.ShoppingListRepository.GetByIdAsync(shoppingListDto.Id);
            if(currentShoppingList is null)
            {
                return BadRequest("The specified shopping list not found!");
            }
            
            var users = await _unitOfWork.UserRepository
                                .GetUsersByUsernamesAsync(shoppingListDto.Members
                                                                            .Select(m => m.Username));            

            var shoppingList = _mapper.Map<ShoppingList>(shoppingListDto);
            shoppingList.Members = users.ToList();

            currentShoppingList.Modified = DateTime.Now;
            currentShoppingList.Title = shoppingList.Title;
            currentShoppingList.Members = shoppingList.Members;
            currentShoppingList.Items = shoppingList.Items;

            if(await _unitOfWork.CompleteAsync())
            {
                return Ok(new { Message = "Shopping list has been modified successfully!" });
            }

            return Ok(new { Message = "No changes have been made" });
        }
    }
}