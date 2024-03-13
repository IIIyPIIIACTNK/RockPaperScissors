using Grpc.Net.Client;
using Web.API;

namespace ConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7271");
            var userClient = new User.UserClient(channel);
            Console.WriteLine("Введите имя!");
            var input = Console.ReadLine();

            var request = new CreateRequest { Name = input };

            var reply = await userClient.CreateUserAsync(request);

            var userRequest = new GetRequest { Id = reply.Message };


            var userReply = await userClient.GetUserAsync(userRequest);
            Console.WriteLine(userReply.Id);
            await Console.Out.WriteLineAsync(userReply.Name);
            await Console.Out.WriteLineAsync(userReply.Balance);
            Console.ReadLine();
        }
    }
}
