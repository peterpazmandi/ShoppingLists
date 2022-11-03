using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<IActionResult> UpdateItemBoughtStateById(UpdateItemBoughtDto itemDto)
        {
            await _unitOfWork.ItemRepository.UpdateItemBoughtStateById(itemDto.ItemId, itemDto.Bought);

            if (await _unitOfWork.CompleteAsync())
            {
                return Ok(new 
                { 
                    HttpStatusCode = HttpStatusCode.OK,
                    Message = "Item updated successfully!"
                });
            }

            return BadRequest(new 
            { 
                HttpStatusCode = HttpStatusCode.BadRequest,
                Message = "Operation failed!"
            });
        }
    }
}