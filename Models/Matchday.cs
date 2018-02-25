using System;
using System.Collections.Generic;

namespace SM.API.Models
{
    public class Matchday
    {
        public Matchday()
        {
            Matches = new List<Match>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int SeasonId { get; set; }

        public Season Season { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}