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
        }
    }
}