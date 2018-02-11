using System;
using System.Collections.Generic;
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
            var matches = GetMatches();

            var predictors = GetPredictors();

            var matchday = new MatchdaysDto
            {
                Id = 1,
                Title = "EPL 2017-18: Matchday 27",
                Matches = matches,
                Predictors = predictors
            };

            var matchdays = new List<MatchdaysDto>
            {
                matchday
            };

            return Ok(matchdays);
        }

        private IEnumerable<MatchDto> GetMatches()
        {
            return new List<MatchDto>
            {
                new MatchDto
                {
                    Id = 1,
                    Home = "Tottenham Hotspur",
                    Away = "Arsenal",
                    Result = "1-0",
                    Date = new DateTime(2018, 2, 10)
                },
                new MatchDto
                {
                    Id = 2,
                    Home = "Manchester City",
                    Away = "Leicester City",
                    Result = "5-1",
                    Date = new DateTime(2018, 2, 10)
                },
                new MatchDto
                {
                    Id = 3,
                    Home = "Newcastle United",
                    Away = "Manchester United",
                    Result = "1-0",
                    Date = new DateTime(2018, 2, 11)
                },
                new MatchDto
                {
                    Id = 4,
                    Home = "Southampton",
                    Away = "Liverpool",
                    Result = "-",
                    Date = new DateTime(2018, 2, 11)
                },
                new MatchDto
                {
                    Id = 5,
                    Home = "Chelsea",
                    Away = "West Bromwich Albion",
                    Result = "-",
                    Date = new DateTime(2018, 2, 12)
                }
            };
        }

        private int predictorIdx = 0;
        private IEnumerable<PredictorDto> GetPredictors()
        {
            return new List<PredictorDto>
            {
                new PredictorDto
                {
                    Id = ++predictorIdx,
                    User = "Nut",
                    Predictions = GetPredictions("Nut"),
                    TotalPoint = 2
                },
                new PredictorDto
                {
                    Id = ++predictorIdx,
                    User = "Sun",
                    Predictions = GetPredictions("Sun"),
                    TotalPoint = 2
                },
                new PredictorDto
                {
                    Id = ++predictorIdx,
                    User = "Boss",
                    Predictions = GetPredictions("Boss"),
                    TotalPoint = 1
                },
                new PredictorDto
                {
                    Id = ++predictorIdx,
                    User = "No",
                    Predictions = GetPredictions("No"),
                    TotalPoint = 1
                },
                new PredictorDto
                {
                    Id = ++predictorIdx,
                    User = "Yong",
                    Predictions = GetPredictions("Yong"),
                    TotalPoint = 1
                }
            };
        }

        private int predictionIdx = 0;
        private IEnumerable<PredictionDto> GetPredictions(string user)
        {
            if (user == "Nut")
            {
                return new List<PredictionDto>
                {
                    new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "TOT",
                        AwayAbbreviation = "ARS",
                        Result = "3-2",
                        Point = 1
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "MCI",
                        AwayAbbreviation = "LEI",
                        Result = "2-0",
                        Point = 1
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "NEW",
                        AwayAbbreviation = "MUN",
                        Result = "0-2",
                        Point = 0
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "SOU",
                        AwayAbbreviation = "LIV",
                        Result = "0-3",
                        Point = null
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "CHE",
                        AwayAbbreviation = "WBA",
                        Result = "1-1",
                        Point = null
                    }
                };
            }
            else if (user == "Sun")
            {
                return new List<PredictionDto>
                {
                    new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "TOT",
                        AwayAbbreviation = "ARS",
                        Result = "2-1",
                        Point = 1
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "MCI",
                        AwayAbbreviation = "LEI",
                        Result = "3-0",
                        Point = 1
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "NEW",
                        AwayAbbreviation = "MUN",
                        Result = "0-2",
                        Point = 0
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "SOU",
                        AwayAbbreviation = "LIV",
                        Result = "1-2",
                        Point = null
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "CHE",
                        AwayAbbreviation = "WBA",
                        Result = "2-0",
                        Point = null
                    }
                };
            }
            else if (user == "Boss")
            {
                return new List<PredictionDto>
                {
                    new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "TOT",
                        AwayAbbreviation = "ARS",
                        Result = "1-2",
                        Point = 0
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "MCI",
                        AwayAbbreviation = "LEI",
                        Result = "3-1",
                        Point = 1
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "NEW",
                        AwayAbbreviation = "MUN",
                        Result = "1-1",
                        Point = 0
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "SOU",
                        AwayAbbreviation = "LIV",
                        Result = "1-3",
                        Point = null
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "CHE",
                        AwayAbbreviation = "WBA",
                        Result = "3-0",
                        Point = null
                    }
                };
            }
            else if (user == "No")
            {
                return new List<PredictionDto>
                {
                    new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "TOT",
                        AwayAbbreviation = "ARS",
                        Result = "2-2",
                        Point = 0
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "MCI",
                        AwayAbbreviation = "LEI",
                        Result = "3-1",
                        Point = 1
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "NEW",
                        AwayAbbreviation = "MUN",
                        Result = "0-1",
                        Point = 0
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "SOU",
                        AwayAbbreviation = "LIV",
                        Result = "1-1",
                        Point = null
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "CHE",
                        AwayAbbreviation = "WBA",
                        Result = "2-0",
                        Point = null
                    }
                };
            }
            else if (user == "Yong")
            {
                return new List<PredictionDto>
                {
                    new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "TOT",
                        AwayAbbreviation = "ARS",
                        Result = "1-2",
                        Point = 0
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "MCI",
                        AwayAbbreviation = "LEI",
                        Result = "2-1",
                        Point = 1
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "NEW",
                        AwayAbbreviation = "MUN",
                        Result = "0-2",
                        Point = 0
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "SOU",
                        AwayAbbreviation = "LIV",
                        Result = "1-3",
                        Point = null
                    }, new PredictionDto
                    {
                        Id = ++predictionIdx,
                        HomeAbbreviation = "CHE",
                        AwayAbbreviation = "WBA",
                        Result = "1-0",
                        Point = null
                    }
                };
            }

            return new List<PredictionDto>();
        }
    }
}