using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.VisualBasic;
using System.Drawing;

namespace mikubot.Modules
{
    public class ExampleCommands : ModuleBase
    {
        [Command("talktomiku")]
        [Alias("hello!")]
        public async Task HelloCommand([Remainder]string args = null)
        {            
            var sb = new StringBuilder();
            var embed = new EmbedBuilder();

            var replies = new List<string>();

            replies.Add("My name is Miku!");
            replies.Add("I am Miku!");
            replies.Add("Sleepy...");
            replies.Add("https://tenor.com/view/anime-hatsune-miku-excited-happy-gif-12331671");

            embed.WithColor(new Discord.Color(0, 255, 0));
            embed.Title = "Chat with Miku!";
                        
            sb.AppendLine($" [{Context.User.Username}]");
            sb.AppendLine();

            if (args == null)
            {
                sb.AppendLine("Are you going to say something?");
            }
            else
            {
                var answer = replies[new Random().Next(replies.Count - 1)];

                sb.AppendLine($"[**{args}**]...");
                sb.AppendLine();
                sb.AppendLine($"...[**{answer}**]");
                
                switch (answer)
                {
                    case "My name is Miku!":
                        {
                            embed.WithColor(new Discord.Color(0, 255, 0));
                            break;
                        }
                    case "I am Miku!":
                        {
                            embed.WithColor(new Discord.Color(255, 0, 0));
                            break;
                        }
                    case "Sleepy...":
                        {
                            embed.WithColor(new Discord.Color(255, 255, 0));
                            break;
                        }
                    case "https://tenor.com/view/anime-hatsune-miku-excited-happy-gif-12331671":
                        {
                            embed.WithColor(new Discord.Color(255, 255, 255));
                            break;
                        }
            }

            await ReplyAsync(sb.ToString());
        }        

        [Command("8ball")]
        [Alias("ask")]
        public async Task AskEightBall([Remainder]string args = null)
        {
            var sb = new StringBuilder();
            var embed = new EmbedBuilder();

            var replies = new List<string>();

            replies.Add("Yes");
            replies.Add("No");
            replies.Add("Maybe");
            replies.Add("Ask again");
            replies.Add("Miku doesn't know");
            replies.Add("Too tired to answer...");

            embed.WithColor(new Discord.Color(0, 255, 0));
            embed.Title = "Welcome to the 8-ball!";

            sb.AppendLine($"{Context.User.Username},");
            sb.AppendLine();

            if (args == null)
            {
                sb.AppendLine("I can't answer your question if you don't ask it!");
            }
            else
            {
                var answer = replies[new Random().Next(replies.Count - 1)];

                sb.AppendLine($"You asked: [**{args}**]...");
                sb.AppendLine();
                sb.AppendLine($"... [**{answer}**]");

                switch (answer)
                {
                    case "yes":
                        {
                            embed.WithColor(new Discord.Color(0, 255, 0));
                            break;
                        }
                    case "no":
                        {
                            embed.WithColor(new Discord.Color(255, 0, 0));
                            break;
                        }
                    case "maybe":
                        {
                            embed.WithColor(new Discord.Color(255, 255, 0));
                            break;
                        }
                    case "ask again":
                        {
                            embed.WithColor(new Discord.Color(255, 255, 255));
                            break;
                        }
                    case "Miku doesn't know":
                        {
                            embed.WithColor(new Discord.Color(255, 0, 255));
                            break;
                        }
                    case "Too tired to answer...":
                        {
                            embed.WithColor(new Discord.Color(0, 0, 255));
                            break;
                        }
                }
            }

            embed.Description = sb.ToString();

            await ReplyAsync(null, false, embed.Build());
        }
    }
}