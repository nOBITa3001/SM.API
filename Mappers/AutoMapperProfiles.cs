using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SM.API.DTOs;
using SM.API.Models;

namespace SM.API.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();

            CreateMap<User, UserForDetailedDto>();

            CreateMap<Match, MatchDto>()
                .ForMember(dest => dest.Home, opt => opt.MapFrom(src => src.HomeTeam.ShortName))
                .ForMember(dest => dest.Away, opt => opt.MapFrom(src => src.AwayTeam.ShortName));

            CreateMap<Matchday, MatchdayDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => $"{src.Season.League.Abbreviation} {src.Season.Title}: {src.Title}"))
                .ForMember(dest => dest.Predictors, opt => opt.MapFrom(src => MapToPredictors(src.Matches.SelectMany(m => m.Predictions))));

            CreateMap<Prediction, PredictionDto>()
                .ForMember(dest => dest.HomeAbbreviation, opt => opt.MapFrom(src => src.Match.HomeTeam.Abbreviation))
                .ForMember(dest => dest.AwayAbbreviation, opt => opt.MapFrom(src => src.Match.AwayTeam.Abbreviation));

            CreateMap<Prediction, PredictionDto>()
                .ForMember(dest => dest.HomeAbbreviation, opt => opt.MapFrom(src => src.Match.HomeTeam.Abbreviation))
                .ForMember(dest => dest.AwayAbbreviation, opt => opt.MapFrom(src => src.Match.AwayTeam.Abbreviation));
        }

        private IEnumerable<PredictorDto> MapToPredictors(IEnumerable<Prediction> predictions)
        {
            var result =
            (
                from prediction in predictions
                group prediction by prediction.User into groupedPrediction
                select new PredictorDto
                {
                    User = groupedPrediction.Key.Username,
                    Predictions = Mapper.Map<IEnumerable<PredictionDto>>(groupedPrediction)
                }
            );

            return result
                .OrderByDescending(r => r.TotalPoint)
                .ThenBy(r => r.User);
        }
    }
}