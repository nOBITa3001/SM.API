namespace SM.API.DTOs
{
    public class RankDto
    {
        public int Sequence { get; set; }
        public string User { get; set; }
        public int TotalPoint { get; set; }
        public int TotalGame { get; set; }
        public decimal WinningRate => (((decimal)(TotalCorrectScore + TotalCorrectResult) / TotalGame) * 100);
        public int TotalCorrectScore { get; set; }
        public int TotalCorrectResult { get; set; }
        public int TotalWrong { get; set; }
    }
}