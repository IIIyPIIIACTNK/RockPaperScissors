using BuisnessLogic.Services.Abstractions;
using BuisnessLogic.Contracts.User;
using Grpc.Core;

namespace Web.API.Services
{
    public class UserGrpcService : User.UserBase
    {
        private readonly IUserService _userService;

        public UserGrpcService(IUserService userService)
        {
            _userService = userService;
        }

        public override async Task<CreateReply> CreateUser(CreateRequest request, ServerCallContext context)
        {
            CreateReply output = new CreateReply();

            var userId = await _userService.CreateAsync(new UserDto() { Name = request.Name, Balance = 1000 });

            output.Message = $"{userId}";

            return output;
        }

        public override async Task<GetReply> GetUser(GetRequest request, ServerCallContext context)
        {
            var user = await _userService.GetByIdAsync(request.Id);

            GetReply output = new GetReply() {
                Id = user.Id,
                Name = user.Name,
                Balance = user.Balance.ToString()
            };

            return output;
        }
    }
}
