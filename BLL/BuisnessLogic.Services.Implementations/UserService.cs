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

        public async Task UpdateAsync(string id, UserDto userDto)
        {
            var user = await _userRepository.GetAsync(id);
            if(user == null)
            {
                throw new Exception($"Не существует пользователя с id {id}");
            }
            user.Balance = userDto.Balance;
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
