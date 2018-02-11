namespace SM.API.DTOs
{
    public class PredictionDto
    {
        public int Id { get; set; }
        public string HomeAbbreviation { get; set; }
        public string AwayAbbreviation { get; set; }
        public string Result { get; set; }
        public int? Point { get; set; }
    }
}