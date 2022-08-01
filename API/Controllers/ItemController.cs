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
    public class ItemController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Authorize]
        [HttpPost("UpdateItemBoughtStateById")]
        public async Task<IActionResult> UpdateItemBoughtStateById(int itemId, bool bought)
        {
            await _unitOfWork.ItemRepository.UpdateItemBoughtStateById(itemId, bought);

            if (await _unitOfWork.CompleteAsync())
            {
                return Ok("Item updated successfully!");
            }

            return BadRequest("Operation failed!");
        }
    }
}