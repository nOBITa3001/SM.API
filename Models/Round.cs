using System;

namespace SM.API.Models
{
    public class Round
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Sequence { get; set; }
        public int CompetitionId { get; set; }

        public Competition Competition { get; set; }
    }
}