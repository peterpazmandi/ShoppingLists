using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class MemberController : BaseApiController
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberController(ILogger<MemberController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("FindMembersByUsername")]
        public async Task<IActionResult> FindMembersByUsername(string username)
        {
            var members = await _unitOfWork.UserRepository.GetUsersByUsernameAsync(username);
            return Ok(_mapper.Map<IEnumerable<UsernameDto>>(members));
        }
    }
}