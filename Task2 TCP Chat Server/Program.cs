namespace Task2_TCP_Chat_Server
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Server server = new Server();// создаем сервер
            await server.StartServer();
        }
    }
}