using AutoMapper;
using BuisnessLogic.Contracts.Transaction;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Implementations.Mapping
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<TransactionDto, Transaction>();
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
