using AutoMapper;
using BuisnessLogic.Contracts.Match;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Implementations.Mapping
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<MatchDto, Match>();
            CreateMap<Match, MatchDto>();
        }
        
    }
}
