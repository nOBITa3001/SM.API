using System;
using System.Collections.Generic;

namespace SM.API.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int SeasonId { get; set; }

        public Season Season { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public ICollection<Group> Groups { get; set; }

        public Competition()
        {
            Teams = new List<Team>();
        }
    }
}