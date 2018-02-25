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
    public class MatchdaysController : Controller
    {
        private readonly ISMRepository _repo;
        private readonly IMapper _mapper;
        public MatchdaysController(ISMRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var matchdays = await _repo.GetMatchdaysAsync();

            var dtos = _mapper.Map<IEnumerable<MatchdayDto>>(matchdays);

            return Ok(dtos);
        }
    }
}