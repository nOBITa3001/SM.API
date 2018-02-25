using System.Collections.Generic;

namespace SM.API.Models
{
    public class League
    {
        public League()
        {
            Seasons = new List<Season>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        
        public ICollection<Season> Seasons { get; set; }
    }
}