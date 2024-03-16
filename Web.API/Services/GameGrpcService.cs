using BuisnessLogic.Services.Abstractions;
using BuisnessLogic.Contracts.Match;
using Grpc.Core;
using AutoMapper;

namespace Web.API.Services
{
    public class GameGrpcService : Game.GameBase
    {
        private readonly IMatchService _matchService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GameGrpcService(IMatchService matchService, IUserService userService, IMapper mapper)
        {
            _matchService = matchService;
            _userService = userService;
            _mapper = mapper;
        }

        public override async Task<CreateGameReply> CreateGame(CreateGameRequest request, ServerCallContext context)
        {
            var createUser = _mapper.Map<DataAccess.Entities.User>(await _userService.GetByIdAsync(request.UserId));
            var gameId = await _matchService.CreateAsync(
                new MatchDto()
                {
                    Player1 = createUser,
                    Bid = Convert.ToDecimal(request.Bid),
                });;

            return new CreateGameReply() { GameId = gameId};
        }

        public override async Task GetAllGames(GetAllGamesRequest request, IServerStreamWriter<GetGameResponce> responseStream, ServerCallContext context)
        {
            List<MatchDto> games = await _matchService.GetAllAsync();
            foreach (var item in games)
            {
                await responseStream.WriteAsync(message: new GetGameResponce() { 
                    Bid = item.Bid.ToString(),
                    GameId = item.Id,
                    User1Id = item.Player1.Id,
                    User2Id = item.Player2.Id,
                });
            }
        }
    }
}
