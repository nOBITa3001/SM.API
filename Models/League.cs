using System.Collections.Generic;

namespace SM.API.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public ICollection<Season> Seasons { get; set; }
    }
}