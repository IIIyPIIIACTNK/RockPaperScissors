using AutoMapper;
using BuisnessLogic.Contracts.GameTransactions;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Implementations.Mapping
{
    public class GameTransactionProfile : Profile
    {
        public GameTransactionProfile()
        {
            CreateMap<GameTransactionsDto, GameTransactions>();
            CreateMap<GameTransactions, GameTransactionsDto>();
        }
    }
}
