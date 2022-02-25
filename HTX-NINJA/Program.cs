using Discord;
using Discord.Commands;
using Discord.WebSocket;
using HTX_NINJA.Zooqle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTX_NINJA
{
    internal class Program
    {
        string prefix = "!";
        static void Main(string[] args)
        {
            Thread tr = new Thread(() => new Program().RunBotAsync().GetAwaiter().GetResult());
            tr.Start();
            tr.Join();
        }


        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
             
            //_services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider(); 

            _client.Log += _client_Log;
            _client.Ready += _client_Ready;
            _client.ButtonExecuted += _client_ButtonExecuted;
            _client.SelectMenuExecuted += _client_SelectMenuExecuted;

            string token = "";
            try { token = File.ReadAllText("token.txt"); } catch { Console.WriteLine("token.txt missing!"); }

            await RegisterCommandsAsync();
            try
            {
                await _client.LoginAsync(TokenType.Bot, token);
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Token not valid, or no Internet connection!");
                Console.ReadLine();
                Environment.Exit(1);
            }

            await _client.StartAsync();

            await Task.Delay(-1); // infinite wait
        }

        private async Task _client_SelectMenuExecuted(SocketMessageComponent arg)
        {
            SearchRequest request = SearchRequest.GetRequestFromUser(arg.User);
            switch (arg.Data.CustomId)
            {
                case "MENU_QUALITY":
                    if (request != null)
                    {
                        string text = string.Join(", ", arg.Data.Values);
                        Quality quality = new Quality();
                        switch (text)
                        {
                            case "3D": quality = Quality._3D; break;
                            case "Ultra": quality = Quality._Ultra; break;
                            case "1080p": quality = Quality._1080p; break;
                            case "Std": quality = Quality._Std; break;
                            case "Med": quality = Quality._Med; break;
                            case "Low": quality = Quality._Low; break;
                        }
                        request.GetCurrentMovie().SelectedQuality = quality;
                        try { await arg.RespondAsync(); } catch { }
                    }
                    break;
            }
        }

        private async Task _client_ButtonExecuted(SocketMessageComponent arg)
        {
            SearchRequest request = SearchRequest.GetRequestFromUser(arg.User);
            switch (arg.Data.CustomId)
            {
                case "MOVIE_SEARCH_NEXT":
                    if (request != null)
                    {
                        request.NextResult();
                        (EmbedBuilder embedbuilder, ComponentBuilder componentbuilder) = request.GetResult();
                        await arg.Message.ModifyAsync(x => x.Embed = embedbuilder.Build());
                        try { await arg.RespondAsync(); } catch { }
                    }
                    break;
                case "MOVIE_SEARCH_BACK":
                    if (request != null)
                    {
                        request.LastResult();
                        (EmbedBuilder embedbuilder, ComponentBuilder componentbuilder) = request.GetResult();
                        await arg.Message.ModifyAsync(x => x.Embed = embedbuilder.Build());
                        try { await arg.RespondAsync(); } catch { }
                    }
                    break;
                case "MOVIE_SEARCH_DOWNLOAD":
                    if (request != null)
                    {
                        // download movie with selected quality
                        try { await arg.RespondAsync(); } catch { }
                    }
                    break;
                case "MOVIE_SEARCH_CANCEL":
                    if (request != null)
                    {
                        GlobalRequests.SearchRequests.Remove(request);
                        try { await arg.Message.DeleteAsync(); } catch { }
                    }
                    break;
            }
        }

        private Task _client_Ready()
        {
            Console.WriteLine("Bot is online and working perfectly fine!");
            new Thread(RPC).Start(); // start the RPC messages
            return Task.CompletedTask;
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg); // log discord.net specific messages (NOT CHAT)
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            Thread thread = new Thread(() => CommandHandler(arg));
            thread.Start();
            thread.Join();
        }

        private async void CommandHandler(SocketMessage arg)
        {
            try
            {
                var message = arg as SocketUserMessage;
                if (message == null) return;
                var context = new SocketCommandContext(_client, message);

                if (message.Author.IsBot) return;

                if (context.IsPrivate) // DM Message
                {
                    var colors = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{DateTime.Now.Hour}-{DateTime.Now.Minute}|[{message.Author}|{message.Author.Id}]:\n");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(message.Content);
                    Console.ForegroundColor = colors;
                }
                else // Everywhere else
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{DateTime.Now.Hour}-{DateTime.Now.Minute}|[{context.Guild.Id}|{context.Guild}|{message.Channel.Id}|{message.Channel}|{message.Author}|{message.Author.Id}|]:\n");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(message.Content);
                    Console.ForegroundColor = color;
                }

                int argPos = 0;
                if (message.HasStringPrefix(prefix.ToLower(), ref argPos) || message.HasStringPrefix(prefix, ref argPos)) // check if message starts with the set prefix
                {
                    //try { await arg.DeleteAsync(); } catch { }

                    var result = await _commands.ExecuteAsync(context, argPos, _services); // execute the command

                    if (!result.IsSuccess)
                    {
                        var colors = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result.ErrorReason);
                        Console.ForegroundColor = colors;
                        await arg.Channel.SendMessageAsync("[ERROR]: " + result.ErrorReason);
                    }
                    if (result.Error.Equals(CommandError.UnmetPrecondition)) await message.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
            catch
            {
                Console.WriteLine("Discord Embed Message Error!"); // not important, just keep it
            }
        }

        private async void RPC() // cycle between messages
        {
            while (true)
            {
                await _client.SetGameAsync("HTX.NINJA");
                Thread.Sleep(5000);
                await _client.SetGameAsync("Best Movie Host");
                Thread.Sleep(5000);
            }
        }
    }
}