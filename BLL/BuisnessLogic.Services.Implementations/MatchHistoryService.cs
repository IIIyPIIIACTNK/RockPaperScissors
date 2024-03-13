using AutoMapper;
using BuisnessLogic.Contracts.MatchHistory;
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
    public class MatchHistoryService : IMatchHistoryService
    {
        private readonly IMapper _mapper;
        private readonly IMatchHistoryRepository _matchHistoryRepository;

        public MatchHistoryService(IMapper mapper, IMatchHistoryRepository matchHistoryRepository)
        {
            _mapper = mapper;
            _matchHistoryRepository = matchHistoryRepository;
        }

        public async Task<string> CreateAsync(MatchHistoryDto MatchHistoryDto)
        {
            var entity = _mapper.Map<MatchHistory>(MatchHistoryDto);
            entity.Id = Guid.NewGuid().ToString();
            var createdUser = await _matchHistoryRepository.AddAsync(entity);
            await _matchHistoryRepository.SaveChangesAsync();
            return createdUser.Id;
        }

        public Task DeleteAsync(string id)
        {
            _matchHistoryRepository.Delete(id);
            return Task.CompletedTask;
        }

        public async Task<MatchHistoryDto> GetByIdAsync(string id)
        {
            var entity = await _matchHistoryRepository.GetAsync(id);
            return _mapper.Map<MatchHistoryDto>(entity);
        }

        public  async Task UpdateAsync(string id, MatchHistoryDto MatchHistoryDto)
        {
            var entity = await _matchHistoryRepository.GetAsync(id);
            if (entity == null)
            {
                throw new Exception($"Не существует сущности с id {id}");
            }
            entity = _mapper.Map<MatchHistory>(MatchHistoryDto);
            _matchHistoryRepository.Update(entity);
            await _matchHistoryRepository.SaveChangesAsync();
        }
    }
}
