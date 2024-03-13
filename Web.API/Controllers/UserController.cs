using BuisnessLogic.Contracts.User;
using BuisnessLogic.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<UserDto> Get(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user;
        }
        [HttpPost]
        public async Task<string> Create(UserDto dto)
        {
            var userId = await _userService.CreateAsync(dto);
            return userId;
        }
    }
}
