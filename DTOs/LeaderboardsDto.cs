using System;
using System.Collections.Generic;

namespace SM.API.DTOs
{
    public class LeaderboardsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<RankDto> Ranks { get; set; }
    }
}
