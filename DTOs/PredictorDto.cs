using System.Collections.Generic;
using System.Linq;

namespace SM.API.DTOs
{
    public class PredictorDto
    {
        public string User { get; set; }
        public IEnumerable<PredictionDto> Predictions { get; set; }
        public int TotalPoint
        {
            get
            {
                return Predictions.Sum(p => p.Point.GetValueOrDefault());
            }
        }
    }
}