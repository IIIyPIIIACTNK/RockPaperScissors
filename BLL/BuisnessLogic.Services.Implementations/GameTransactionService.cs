using AutoMapper;
using BuisnessLogic.Contracts.GameTransactions;
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
    public class GameTransactionService : IGameTransactionService
    {
        private readonly IMapper _mapper;
        private readonly IGameTransactionsRepository _gameTransactionsRepository;

        public GameTransactionService(IMapper mapper, IGameTransactionsRepository gameTransactionsRepository)
        {
            _mapper = mapper;
            _gameTransactionsRepository = gameTransactionsRepository;
        }

        public async Task AddTransaction(TransactionDto dto, string id)
        {
            var entity = await _gameTransactionsRepository.GetAsync(id);
            entity.Transactions.Add(_mapper.Map<Transaction>(dto));
            await _gameTransactionsRepository.SaveChangesAsync();
        }

        public async Task<string> CreateAsync(GameTransactionsDto gameTransactionsDto)
        {
            var entity = _mapper.Map<GameTransactions>(gameTransactionsDto);
            entity.Id = Guid.NewGuid().ToString();
            var createdEntity = await _gameTransactionsRepository.AddAsync(entity);
            await _gameTransactionsRepository.SaveChangesAsync();
            return createdEntity.Id;
        }

        public Task DeleteAsync(string id)
        {
            _gameTransactionsRepository.Delete(id);
            return Task.CompletedTask;
        }

        public async Task<GameTransactionsDto> GetByIdAsync(string id)
        {
            var entity = await _gameTransactionsRepository.GetAsync(id);
            return _mapper.Map<GameTransactionsDto>(entity);
        }

        public async Task UpdateAsync(string id, GameTransactionsDto gameTransactionsDto)
        {
            var entity = await _gameTransactionsRepository.GetAsync(id);
            if (entity == null)
            {
                throw new Exception($"Не существует сущности с id {id}");
            }
            entity.Transactions = gameTransactionsDto.Transactions;
            _gameTransactionsRepository.Update(entity);
            await _gameTransactionsRepository.SaveChangesAsync();
        }
    }
}
