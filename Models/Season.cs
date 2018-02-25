using System.Collections.Generic;

namespace SM.API.Models
{
    public class Season
    {
        public Season()
        {
            Matchdays = new List<Matchday>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int LeagueId { get; set; }

        public League League { get; set; }
        public ICollection<Matchday> Matchdays { get; set; }
    }
}