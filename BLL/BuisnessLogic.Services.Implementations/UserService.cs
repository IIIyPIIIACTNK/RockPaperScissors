using AutoMapper;
using BuisnessLogic.Contracts.User;
using BuisnessLogic.Services.Abstractions;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;

namespace BuisnessLogic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<string> CreateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid().ToString();
            var createdUser = await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return createdUser.Id;
        }

        public Task DeleteAsync(string id)
        {
             _userRepository.Delete(id);
             return Task.CompletedTask;
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByName(string name)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetByName(name));
        }

        public async Task UpdateAsync(string id, UserDto userDto)
        {
            var entity = await _userRepository.GetAsync(id);
            if(entity == null)
            {
                throw new Exception($"Не существует сущности с id {id}");
            }
            entity.Balance = userDto.Balance;
            _userRepository.Update(entity);
            await _userRepository.SaveChangesAsync();
        }
    }
}
