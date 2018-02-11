using System.Collections.Generic;

namespace SM.API.DTOs
{
    public class PredictorDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public IEnumerable<PredictionDto> Predictions { get; set; }
        public int TotalPoint { get; set; }
    }
}