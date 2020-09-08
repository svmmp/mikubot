using System;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace mikubot
{
    class Program
    {
        private readonly DiscordSocketClient _client;
        private readonly IConfiguration _config;

        static void Main(String[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();            
        }

        public Program()
        {
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;

            _client.Ready += ReadyAsync;

            _client.MessageReceived += MessageReceivedAsync;

            var _builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(path: "config.json");
            _config = _builder.Build();
        }

        public async Task MainAsync()
        {
            await _client.LoginAsync(TokenType.Bot, _config["Token"]);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private Task ReadyAsync()
        {
            Console.WriteLine($"Connected as -> [{_client.CurrentUser}] :)");
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
                return;
            
            if (message.Content == ".hello")
            {
                await message.Channel.SendMessageAsync("world!");
            }
        }
    }
}