using Grpc.Core;
using Grpc.Net.Client;

namespace ConsoleClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7271");
            var _userClient = new User.UserClient(channel);
            var _gameClient = new Game.GameClient(channel); 
            Console.WriteLine("Введите имя!");
            var input = Console.ReadLine();

            {
                var createUserRequet = new CreateRequest { Name = input };
                var createUserReply = await _userClient.CreateOrGetUserAsync(createUserRequet);
                UserMetadata.Id = createUserReply.Message;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Доступные комманды:\n " +
                "/getallgames - получить список игр " +
                "\n /creategame - создать игру" +
                "\n /exit - выйти из программы" +
                "\n====================");
            Console.ForegroundColor = ConsoleColor.White;
            bool exit = false;
            while (!exit)
            {
                Console.Write("Введите комманду || ");
                var commandInput = Console.ReadLine();

                switch (commandInput)
                {
                    case ("/exit"):
                        exit = true;
                        break;
                    case ("/creategame"):
                        Console.WriteLine("Ваша ставка");
                        var bidInput = Console.ReadLine();
                        try
                        {
                            Convert.ToDecimal(bidInput);
                            var createGameRequest = new CreateGameRequest() {
                                Bid = bidInput,
                                UserId = UserMetadata.Id
                            };
                            var createGameResponce = await _gameClient.CreateGameAsync(createGameRequest);
                        }
                        catch (Exception ex)
                        {
                            
                        }
                        break;
                    case ("/getallgames"):
                        using (var call = _gameClient.GetAllGames(new GetAllGamesRequest()))
                        {
                            while(await call.ResponseStream.MoveNext())
                            {
                                var currentGame = call.ResponseStream.Current;

                                await Console.Out.WriteLineAsync($"Id {currentGame.GameId}" +
                                    $"\n Bid {currentGame.Bid}" +
                                    $"\n Player {currentGame.User1Id}");
                                await Console.Out.WriteLineAsync();
                            }
                            await Console.Out.WriteLineAsync();
                        }
                            break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Такой комманды не существует");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
    }
}
