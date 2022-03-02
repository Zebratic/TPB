using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using HTX_NINJA.Zooqle;
using Newtonsoft.Json;
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
            _client.SlashCommandExecuted += _client_SlashCommandExecuted;

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

        private async Task _client_SlashCommandExecuted(SocketSlashCommand arg)
        {
            Console.WriteLine(arg.CommandName + "  |  " + arg.Data.Options.First().Value);
            switch (arg.CommandName)
            {
                case "search":
                    var User = arg.User;
                    await arg.DeferAsync(true);
                    try
                    {
                        SearchRequest request = new SearchRequest(User);
                        request.SearchForMovie(arg.Data.Options.First().Value.ToString());
                        (EmbedBuilder embedbuilder, ComponentBuilder componentbuilder) = request.GetResult();
                        GlobalRequests.SearchRequests.Add(request);
                        await arg.FollowupAsync(embed: embedbuilder.Build(), components: componentbuilder.Build());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        await arg.FollowupAsync(ex.ToString());
                    }
                    break;
            }
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
            try
            {
                SearchRequest request = SearchRequest.GetRequestFromUser(arg.User);
                Console.WriteLine(arg.Data.CustomId);
                switch (arg.Data.CustomId)
                {
                    case "MOVIE_SEARCH_NEXT":
                        if (request != null)
                        {
                            request.NextResult();
                            (EmbedBuilder embedbuilder, ComponentBuilder componentbuilder) = request.GetResult();
                            if (embedbuilder != null)
                                try { await arg.UpdateAsync(x => x.Embed = embedbuilder.Build()); } catch { }
                            if (componentbuilder != null)
                                try { await arg.UpdateAsync(x => x.Components = componentbuilder.Build()); } catch { }
                        }
                        break;
                    case "MOVIE_SEARCH_BACK":
                        if (request != null)
                        {
                            request.LastResult();
                            (EmbedBuilder embedbuilder, ComponentBuilder componentbuilder) = request.GetResult();
                            if (embedbuilder != null)
                                try { await arg.UpdateAsync(x => x.Embed = embedbuilder.Build()); } catch { }
                            if (componentbuilder != null)
                                try { await arg.UpdateAsync(x => x.Components = componentbuilder.Build()); } catch { }
                        }
                        break;
                    case "MOVIE_SEARCH_DOWNLOAD":
                        if (request != null)
                        {
                            try
                            {
                                await arg.DeferLoadingAsync(true);
                                MovieInfo selectedmovie = request.GetCurrentMovie();
                                Console.WriteLine(selectedmovie.URL);
                                selectedmovie.Torrents = new List<TorrentInfo>(); // clear last results if any
                                try { selectedmovie.GetMovieInfo(true, true, selectedmovie.SelectedQuality); } catch { }

                                List<TorrentInfo> sortedtorrents = selectedmovie.Torrents.OrderByDescending(o => o.Seeders).ToList();

                                /* // LOGGING
                                foreach (TorrentInfo torrent in sortedtorrents)
                                {
                                    Console.WriteLine($"[TORRENT] " + torrent.Title.PadRight(65) + $" | {torrent.Seeders} Seeds ".PadRight(15) + $" | {torrent.Leechers} Leeches ".PadRight(15) + $"| {torrent.FileSize}"); ;
                                    // set torrent.magnet to download queue
                                }
                                */

                                TorrentInfo torrent = sortedtorrents.First();

                                

                                torrent.StartDownload();

                                /* All needed now is:
                                    - Torrent downloading
                                    - Notify user when download is done (might not be added)
                                    - Backup magnet to a txt file
                                    - Add file size security check (above 10 gb, notify me)
                                    - Calculate estimated time for download to finish
                                 */

                                // save torrent magnet in backup link
                                // start torrent download using magnet
                                // detect? when torrent done and ping/DM user with request.User
                                //if (torrent.FileSize > 10 GB)
                                //        notify myself if its alright


                                EmbedBuilder embedBuilder = new EmbedBuilder();
                                embedBuilder.WithTitle($"{selectedmovie.Title} is now being downloaded!");
                                embedBuilder.AddField("Quality", torrent.Quality.GetQualityString(), true);
                                embedBuilder.AddField("File Size", torrent.FileSize, true);
                                embedBuilder.AddField("Upload Date", torrent.UploadDate, true);
                                embedBuilder.AddField("Seeders", torrent.Seeders, true);
                                embedBuilder.AddField("Leechers", torrent.Leechers, true);
                                embedBuilder.AddField("ETA", "CALCULATE TIME HERE", true);
                                embedBuilder.WithThumbnailUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Eo_circle_light-green_checkmark.svg/2048px-Eo_circle_light-green_checkmark.svg.png");
                                embedBuilder.WithFooter($"HTX.NINJA | Zebratic#6969");
                                try { await arg.FollowupAsync(embed: embedBuilder.Build()); } catch (Exception ex) { Console.WriteLine(ex); }
                                GlobalRequests.SearchRequests.Remove(request);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                        break;
                    case "MOVIE_SEARCH_CANCEL":
                        if (request != null)
                        {
                            try
                            {
                                await arg.DeferLoadingAsync(true);
                                GlobalRequests.SearchRequests.Remove(request);
                                EmbedBuilder embedBuilder = new EmbedBuilder();
                                embedBuilder.WithTitle("Search has been cancelled!");
                                embedBuilder.WithDescription("You can now dismiss the message.");
                                embedBuilder.WithThumbnailUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Eo_circle_light-green_checkmark.svg/2048px-Eo_circle_light-green_checkmark.svg.png");
                                embedBuilder.WithFooter($"HTX.NINJA | Zebratic#6969");
                                try { await arg.UpdateAsync(x => x.Embed = embedBuilder.Build()); } catch (Exception ex) { Console.WriteLine(ex); }
                                // delete msg if possible
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task _client_Ready()
        {
            Console.WriteLine("Bot is online and working perfectly fine!");
            new Thread(RPC).Start(); // start the RPC messages

            var globalCommand = new SlashCommandBuilder();
            globalCommand.WithName("search");
            globalCommand.WithDescription("Search for any Movie, Series, TV-Show and Anime!");
            globalCommand.AddOption("name", ApplicationCommandOptionType.String, "The name of the Movie, Series, TV-Show or Anime:", true, false, false);

            try
            {
                await _client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
            }
            catch (ApplicationCommandException exception)
            {
                var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
                Console.WriteLine(json);
            }
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