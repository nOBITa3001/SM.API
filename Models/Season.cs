namespace SM.API.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LeagueId { get; set; }

        public League League { get; set; }
    }
}