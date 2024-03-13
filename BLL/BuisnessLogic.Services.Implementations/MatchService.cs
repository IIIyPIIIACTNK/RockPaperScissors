using AutoMapper;
using BuisnessLogic.Contracts.Match;
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
    public class MatchService : IMatchService
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }
        public async Task<string> CreateAsync(MatchDto matchDto)
        {
            var match = _mapper.Map<Match>(matchDto);
            match.Id = Guid.NewGuid().ToString();
            var createdMatch = await _matchRepository.AddAsync(match);
            await _matchRepository.SaveChangesAsync();
            return createdMatch.Id;
        }

        public Task DeleteAsync(string id)
        {
            _matchRepository.Delete(id); 
            return Task.CompletedTask;
        }

        public async Task<MatchDto> GetByIdAsync(string id)
        {
            var match = await _matchRepository.GetAsync(id);
            return _mapper.Map<MatchDto>(match);
        }

        public async Task UpdateAsync(string id, MatchDto matchDto)
        {
            var match = await _matchRepository.GetAsync(id);
            if (match == null)
            {
                throw new Exception($"Не существует пользователя с id {id}");
            }
            
            _matchRepository.Update(match);
            await _matchRepository.SaveChangesAsync();
        }
    }
}
