using System;
using System.Collections.Generic;

namespace SM.API.DTOs
{
    public class MatchdayDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<MatchDto> Matches { get; set; }
        public IEnumerable<PredictorDto> Predictors { get; set; }
    }
}
