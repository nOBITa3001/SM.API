using System;

namespace SM.API.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }
    }
}