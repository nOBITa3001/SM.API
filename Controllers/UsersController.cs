using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SM.API.Data;
using SM.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SM.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ISMRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(ISMRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repo.GetUsersAsync();

            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(userToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _repo.GetUserAsync(id);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }
    }
}