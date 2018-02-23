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
            var orderedRanks = GetOrderedRanks();

            var leaderboard = new LeaderboardsDto
            {
                Id = 1,
                Title = "EPL 2017-18: Matchday 27",
                Ranks = orderedRanks
            };

            var leaderboards = new List<LeaderboardsDto>
            {
                leaderboard
            };

            return Ok(leaderboards);
        }

        private IEnumerable<RankDto> GetOrderedRanks()
        {
            var ranks = new List<RankDto>
            {
                new RankDto
                {
                    User = "Nut",
                    TotalPoint = 3,
                    TotalGame = 5,
                    TotalCorrectScore = 0,
                    TotalCorrectResult = 3,
                    TotalWrong = 2
                },
                new RankDto
                {
                    User = "Sun",
                    TotalPoint = 4,
                    TotalGame = 5,
                    TotalCorrectScore = 0,
                    TotalCorrectResult = 4,
                    TotalWrong = 1
                },
                new RankDto
                {
                    User = "Boss",
                    TotalPoint = 5,
                    TotalGame = 5,
                    TotalCorrectScore = 1,
                    TotalCorrectResult = 2,
                    TotalWrong = 2
                },
                new RankDto
                {
                    User = "Yong",
                    TotalPoint = 3,
                    TotalGame = 5,
                    TotalCorrectScore = 0,
                    TotalCorrectResult = 3,
                    TotalWrong = 2
                },
                new RankDto
                {
                    User = "No",
                    TotalPoint = 2,
                    TotalGame = 5,
                    TotalCorrectScore = 0,
                    TotalCorrectResult = 2,
                    TotalWrong = 3
                }
            };

            var sequenceIndex = 0;
            return ranks
                    .OrderByDescending(r => r.TotalPoint)
                    .ThenByDescending(r => r.TotalCorrectScore)
                    .ThenByDescending(r => r.TotalCorrectResult)
                    .ThenByDescending(r => r.WinningRate)
                    .ThenBy(r => r.TotalGame)
                    .ThenBy(r => r.User)
                    .Select(r => new RankDto
                    {
                        Sequence = ++sequenceIndex,
                        User = r.User,
                        TotalPoint = r.TotalPoint,
                        TotalGame = r.TotalGame,
                        TotalCorrectScore = r.TotalCorrectScore,
                        TotalCorrectResult = r.TotalCorrectResult,
                        TotalWrong = r.TotalWrong
                    });
        }
    }
}
