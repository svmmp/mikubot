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

namespace mikubot.Modules
{
    public class ExampleCommand : ModuleBase
    {
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
            replies.Add("...");

            embed.WithColor(new Discord.Color(0, 255, 0));
            embed.Title = "Ask Miku a Yes or No Question!";

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
                        embed.WithColor(new Color(14177041));
                        break;
                    }
                    case "no":
                    {
                        embed.WithColor(new Color(15844367));
                        break;
                    }
                    case "maybe":
                    {
                        embed.WithColor(new Color(7419530));
                        break;
                    }
                    case "ask again":
                    {
                        embed.WithColor(new Color(16580705));
                        break;
                    }
                    case "Miku doesn't know":
                    {
                        embed.WithColor(new Color(10038562));
                        break;
                    }
                    case "Too tired to answer...":
                    {
                        embed.WithColor(new Color(0, 0, 255));
                        break;
                    }
                    case "...":
                    {
                        embed.WithColor(new Color(0, 0, 0));
                        break;
                    }
                }
            }

            embed.Description = sb.ToString();

            await ReplyAsync(null, false, embed.Build());
        }
    }
}