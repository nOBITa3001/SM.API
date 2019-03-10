using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SM.API.Data;
using SM.API.DTOs;

namespace SM.API.Controllers
{
    [Route("api/[controller]")]
    public class LeaderboardsController : Controller
    {
        private readonly ISMRepository _repo;
        private readonly IMapper _mapper;
        public LeaderboardsController(ISMRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetLeaderboardsAsync());
        }
    }
}
