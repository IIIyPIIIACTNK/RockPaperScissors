using BuisnessLogic.Services.Abstractions;
using BuisnessLogic.Contracts.User;
using Grpc.Core;
using AutoMapper;

namespace Web.API.Services
{
    public class UserGrpcService : User.UserBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserGrpcService(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        public override async Task<CreateUserReply> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            var userId = await _userService.CreateAsync(new UserDto() { Name = request.Name, Balance = 1000});

            return new CreateUserReply() {Message = userId };
        }

        public override async Task<GetUserReply> GetUser(GetUserRequest request, ServerCallContext context)
        {
            var user = await _userService.GetByIdAsync(request.Id);
            GetUserReply reply = new GetUserReply() {
                Name = user.Name,
                Balance = user.Balance.ToString(),
                Id = user.Id
            };
            return reply;
        }

        public override async Task<CreateUserReply> CreateOrGetUser(CreateUserRequest request, ServerCallContext context)
        {
            var user = await _userService.GetByName(request.Name);

            if (user == null)
            {
                var userId = await _userService.CreateAsync(new UserDto() { Name = request.Name, Balance = 1000});
                return new CreateUserReply() { Message = userId };
            }
            else
            {
                var userId = user.Id;
                return new CreateUserReply() { Message = userId };
            }
        }
    }
}
