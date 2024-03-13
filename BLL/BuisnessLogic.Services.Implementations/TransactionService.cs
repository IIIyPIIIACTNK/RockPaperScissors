using AutoMapper;
using BuisnessLogic.Contracts.Transaction;
using BuisnessLogic.Contracts.User;
using BuisnessLogic.Services.Abstractions;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }
        public async Task<string> CreateAsync(TransactionDto TransactionDto)
        {
            var entity = _mapper.Map<Transaction>(TransactionDto);
            entity.Id = Guid.NewGuid().ToString();
            var createdUser = await _transactionRepository.AddAsync(entity);
            await _transactionRepository.SaveChangesAsync();
            return createdUser.Id;
        }

        public Task DeleteAsync(string id)
        {
            _transactionRepository.Delete(id);
            return Task.CompletedTask;
        }

        public async Task<TransactionDto> GetByIdAsync(string id)
        {
            var entity = await _transactionRepository.GetAsync(id);
            return _mapper.Map<TransactionDto>(entity);
        }

        public async Task UpdateAsync(string id, TransactionDto userDto)
        {
            var entity = await _transactionRepository.GetAsync(id);
            if (entity == null)
            {
                throw new Exception($"Не существует сущности с id {id}");
            }
            _transactionRepository.Update(entity);
            await _transactionRepository.SaveChangesAsync();
        }
    }
}
