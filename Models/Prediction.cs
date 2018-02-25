namespace SM.API.Models
{
    public class Prediction
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public string Result { get; set; }
        public int? Point { get; set; }

        public Match Match { get; set; }
        public User User { get; set; }
    }
}