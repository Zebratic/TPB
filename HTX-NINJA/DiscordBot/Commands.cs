﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using HTX_NINJA.TPB;
using HTX_NINJA.Zooqle;

namespace HTX_NINJA.DiscordBot
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("search")]
        public async Task Search([Remainder] string term)
        {
            var User = Context.User;
            EmbedBuilder builder = new EmbedBuilder();

            DownloadResults Results = ThePirateBay.DownloadResultsAsync(new PbSearchQuery(term, PbSortMode.Default, TorrentCategory.None)).Result;
            TPB.TorrentInfo[] Torrents = Results.SearchPage.GetTorrents();
            for (int i = 0; i < 3; i++)
            {
                TPB.TorrentInfo torrent = Torrents[i];
                string FixedTitle = torrent.Title.Length > 33 ? torrent.Title.Substring(0, 30) + "..." : torrent.Title;
                string Description = $"{torrent.ContentSize}{torrent.MeasureUnit}\n{torrent.Seeds} Seeders\n{torrent.Leeches} Leechers";

                builder.AddField(FixedTitle, Description, true);
                Console.WriteLine($"[TORRENT]" + FixedTitle.PadRight(65) + $" | {torrent.Seeds} Seeds ".PadRight(15) + $" | {torrent.Leeches} Leeches ".PadRight(15) + $"| {torrent.ContentSize} {torrent.MeasureUnit}"); ;
            }
               
            await ReplyAsync(User.Mention, embed: builder.Build());
        }

        [Command("zooqle")]
        public async Task Search2([Remainder] string term)
        {
            var User = Context.User;
            var components = new ComponentBuilder();
            EmbedBuilder builder = new EmbedBuilder();

            try
            {
                SearchRequest request = new SearchRequest(Context);
                request.SearchForTorrent(term);

                components.WithButton("<", "MOVIE_SEARCH_BACK", ButtonStyle.Secondary);
                components.WithButton("SELECT", "MOVIE_SEARCH_SELECT", ButtonStyle.Success);

                int added = 0;
                foreach (MovieInfo movie in request.Results)
                {
                    if (added == 3)
                        break;
                    else if (movie.TorrentsAvailable != 0)
                    {
                        string FixedTitle = movie.Title.Length > 33 ? movie.Title.Substring(0, 30) + "..." : movie.Title;
                        builder.WithThumbnailUrl(movie.CoverURL);

                        builder.AddField(FixedTitle, "imposter", false);
                        components.WithButton(FixedTitle, $"MOVIE_SELECTED|{movie.Title}", ButtonStyle.Success);
                        added++;
                    }
                }
                components.WithButton(">", "MOVIE_SEARCH_NEXT", ButtonStyle.Secondary);
                components.WithButton("CANCEL", "MOVIE_SEARCH_CANCEL", ButtonStyle.Danger);
                GlobalRequests.SearchRequests.Add(request);
                await ReplyAsync(User.Mention, embed: builder.Build(), components: components.Build());
            }
            catch (Exception ex)
            {
                await ReplyAsync(ex.ToString());
            }
        }
    }
}