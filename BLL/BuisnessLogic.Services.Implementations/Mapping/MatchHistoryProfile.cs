using AutoMapper;
using BuisnessLogic.Contracts.MatchHistory;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Implementations.Mapping
{
    public class MatchHistoryProfile : Profile
    {
        public MatchHistoryProfile()
        {
            CreateMap<MatchHistoryDto, MatchHistory>();
            CreateMap<MatchHistory, MatchHistoryDto>();
        }
    }
}
