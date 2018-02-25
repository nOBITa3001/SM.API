using System;
using System.Collections.Generic;

namespace SM.API.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }

        public int MatchdayId { get; set; }

        public Matchday Matchday { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public ICollection<Prediction> Predictions { get; set; }
    }
}