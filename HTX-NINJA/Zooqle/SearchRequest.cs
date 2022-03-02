using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.IO;
using System.Web;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SuRGeoNix.BitSwarmLib;

namespace HTX_NINJA.Zooqle
{
    public class GlobalRequests
    {
        public static List<SearchRequest> SearchRequests = new List<SearchRequest>();
        public static string BaseURL = "https://zooqle.com/";
    }

    public class SearchRequest
    {
        public SocketUser User { get; set; }
        public string Term { get; set; }
        public List<MovieInfo> Results { get; set; }
        public int CurrentIndex { get; set; }
        public DateTime LastInteraction { get; set; }
        public SearchRequest(SocketUser _user)
        {
            User = _user;
            CurrentIndex = 0;
            Results = new List<MovieInfo>();
            LastInteraction = DateTime.UtcNow;
            new Thread(CloseThread).Start();
        }

        public void CloseThread()
        {
            while ((LastInteraction + TimeSpan.FromMinutes(5)) > DateTime.UtcNow) { Thread.Sleep(1000); }

            GlobalRequests.SearchRequests.Remove(this);
        }

        public static SearchRequest GetRequestFromUser(SocketUser _user) => GlobalRequests.SearchRequests.Find(x => x.User.Id == _user.Id);
    }

    public static class SearchRequestExtensions
    {
        public static void SearchForMovie(this SearchRequest _request, string _term)
        {
            _request.LastInteraction = DateTime.UtcNow;
            _request.Term = _term;

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string html = wc.DownloadString(GlobalRequests.BaseURL + "search?q=" + _term.Replace(" ", "+"));

                string[] movies = html.Split(new[] { "<li title=\"", }, StringSplitOptions.None);

                for (int i = 1; i < movies.Length - 1; i++)
                {
                    MovieInfo movie = new MovieInfo();
                    movie.Title = movies[i].Split(new[] { "\">" }, StringSplitOptions.None)[0];
                    movie.URL = GlobalRequests.BaseURL + movies[i].Split(new[] { "href=\"/" }, StringSplitOptions.None)[1].Split(new[] { "\">" }, StringSplitOptions.None)[0];
                    try { movie.CoverURL = GlobalRequests.BaseURL + movies[i].Split(new[] { "src=\"/" }, StringSplitOptions.None)[1].Split(new[] { "\">" }, StringSplitOptions.None)[0].Replace("2.jpg", "0.jpg"); } catch { }
                    string torrentsavailable_string = movies[i].Split(new[] { "\"></i> " }, StringSplitOptions.None)[1].Split(new[] { " torrents" }, StringSplitOptions.None)[0];
                    movie.TorrentsAvailable = -1;
                    try { movie.TorrentsAvailable = Convert.ToInt32(torrentsavailable_string); } catch { }
                    try { movie.GetMovieInfo(true, false); } catch { }
                    if (movie.TorrentsAvailable > 0 || movie.TorrentsAvailable == -1)
                        _request.Results.Add(movie);
                }
            }
        }

        public static void GetMovieInfo(this MovieInfo _movie, bool GetQuality, bool GetTorrents, Quality qualitySpecific = Quality._Unknown)
        {
            try
            {
                if (_movie != null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                        string html = wc.DownloadString(_movie.URL);

                        string[] qualities = html.Split(new[] { "<tr style=\"border: none !important;\">", }, StringSplitOptions.None);
                        for (int i = 1; i < qualities.Length - 1; i++)
                        {
                            if (GetQuality) // Get Qualities
                            {
                                try
                                {
                                    string quality = qualities[i].Split(new[] { "\"></i> " }, StringSplitOptions.None)[1].Split(new[] { "</span>" }, StringSplitOptions.None)[0];
                                    Console.WriteLine(_movie.Title + " | " + quality);
                                    switch (quality)
                                    {
                                        case "3D": _movie.Qualities.Add(Quality._3D); break;
                                        case "Ultra": _movie.Qualities.Add(Quality._Ultra); break;
                                        case "1080p": _movie.Qualities.Add(Quality._1080p); break;
                                        case "720p": _movie.Qualities.Add(Quality._720p); break;
                                        case "Std": _movie.Qualities.Add(Quality._Std); break;
                                        case "Med": _movie.Qualities.Add(Quality._Med); break;
                                        case "Low": _movie.Qualities.Add(Quality._Low); break;
                                        default: _movie.Qualities.Add(Quality._Unknown); break;
                                    }
                                }
                                catch (Exception ex) { Console.WriteLine(ex); }
                            }

                            if (GetTorrents) // Get Torrents
                            {
                                string quality_name = qualities[i].Split(new[] { "\"></i> " }, StringSplitOptions.None)[1].Split(new[] { "</span>" }, StringSplitOptions.None)[0];
                                string quality_tag = qualities[i].Split(new[] { "href=\"" }, StringSplitOptions.None)[1].Split(new[] { "\"><span " }, StringSplitOptions.None)[0];
                                Quality quality = Quality._Undefined;
                                switch (quality_name)
                                {
                                    case "3D": quality = Quality._3D;  break;
                                    case "Ultra": quality = Quality._Ultra; break;
                                    case "1080p": quality = Quality._1080p; break;
                                    case "720p": quality = Quality._720p; break;
                                    case "Std": quality = Quality._Std; break;
                                    case "Med": quality = Quality._Med; break;
                                    case "Low": quality = Quality._Low; break;
                                    default: quality = Quality._Unknown; break;
                                }

                                if (qualitySpecific == Quality._Unknown || quality == qualitySpecific)
                                {
                                    wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                                    string torrentlisthtml = wc.DownloadString(_movie.URL + quality_tag);
                                    string[] torrents = torrentlisthtml.Split(new[] { "<tr>", }, StringSplitOptions.None);
                                    for (int i2 = 1; i2 < torrents.Length; i2++)
                                    {
                                        try
                                        {
                                            TorrentInfo torrent = new TorrentInfo();
                                            torrent.Quality = quality;
                                            string htmlpath = torrents[i2].Split(new[] { "href=\"/" }, StringSplitOptions.None)[1].Split(new[] { "\">" }, StringSplitOptions.None)[0];
                                            torrent.URL = GlobalRequests.BaseURL + htmlpath;
                                            torrent.Title = torrents[i2].Split(new[] { $"{htmlpath}\">" }, StringSplitOptions.None)[1].Split(new[] { "</a>" }, StringSplitOptions.None)[0];
                                            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                                            string torrent_html = wc.DownloadString(torrent.URL);
                                            torrent.Magnet = "magnet:?" + torrent_html.Split(new[] { "href=\"magnet:?" }, StringSplitOptions.None)[1].Split(new[] { "\">" }, StringSplitOptions.None)[0];

                                            try
                                            {
                                                string infosection = torrent_html.Split(new[] { "<h6>" }, StringSplitOptions.None)[1].Split(new[] { "</h6>" }, StringSplitOptions.None)[0];
                                                try { torrent.Seeders = Convert.ToInt32(infosection.Split(new[] { "title=\"Seeders: " }, StringSplitOptions.None)[1].Split(' ')[0]); } catch { }
                                                try { torrent.Leechers = Convert.ToInt32(infosection.Split(new[] { " | Leechers: " }, StringSplitOptions.None)[1].Split(new[] { "\">" }, StringSplitOptions.None)[0]); } catch { }
                                                try { torrent.FileSize = infosection.Split(new[] { "title=\"File size\"></i>" }, StringSplitOptions.None)[1].Split(new[] { "<span" }, StringSplitOptions.None)[0]; } catch { }
                                                try { torrent.UploadDate = infosection.Split(new[] { "title=\"Date indexed\"></i>" }, StringSplitOptions.None)[1].Split(new[] { "<span" }, StringSplitOptions.None)[0]; } catch { }
                                            }
                                            catch { }

                                            _movie.Torrents.Add(torrent);
                                            Console.WriteLine($"Q: {torrent.Quality} S: {torrent.Seeders} L: {torrent.Leechers} F: {torrent.FileSize}");
                                        }
                                        catch { }
                                    }
                                }
                            }

                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void NextResult(this SearchRequest _request)
        {
            _request.LastInteraction = DateTime.UtcNow;
            _request.CurrentIndex++;
            if (_request.CurrentIndex == _request.Results.Count)
                _request.CurrentIndex = 0;
        }

        public static void LastResult(this SearchRequest _request)
        {
            _request.LastInteraction = DateTime.UtcNow;
            _request.CurrentIndex--;
            if (_request.CurrentIndex < 0)
                _request.CurrentIndex = _request.Results.Count - 1;
        }

        public static MovieInfo GetCurrentMovie(this SearchRequest _request) => _request.Results[_request.CurrentIndex];

        public static (EmbedBuilder, ComponentBuilder) GetResult(this SearchRequest _request)
        {
            _request.LastInteraction = DateTime.UtcNow;
            var components = new ComponentBuilder();
            EmbedBuilder builder = new EmbedBuilder();

            try
            {
                MovieInfo movie = _request.GetCurrentMovie();
                if (movie.TorrentsAvailable != 0)
                {
                    string FixedTitle = movie.Title.Length > 33 ? movie.Title.Substring(0, 30) + "..." : movie.Title;
                    builder.WithTitle(FixedTitle);
                    if (movie.TorrentsAvailable == -1)
                        builder.WithDescription("Unknown amount of Torrents available for download.");
                    else
                        builder.WithDescription(movie.TorrentsAvailable + " Torrents available for download.");
                    builder.WithThumbnailUrl("https://htx.ninja/web/favicon.png");
                    builder.WithImageUrl(movie.CoverURL);
                    builder.WithFooter($"HTX.NINJA | Zebratic#6969 | Result {_request.CurrentIndex + 1} of {_request.Results.Count}");
                }

                var menuBuilder = new SelectMenuBuilder();
                menuBuilder.WithPlaceholder("Select a quality");
                menuBuilder.WithCustomId("MENU_QUALITY");
                menuBuilder.WithMinValues(1);
                menuBuilder.WithMaxValues(1);
                foreach (Quality quality in movie.Qualities)
                {
                    switch (quality)
                    {
                        case Quality._3D: menuBuilder.AddOption("3D (1080p - 2160p)", "3D"); break;
                        case Quality._Ultra: menuBuilder.AddOption("2160p (4K)", "Ultra"); break;
                        case Quality._1080p: menuBuilder.AddOption("1080p", "1080p"); break;
                        case Quality._720p: menuBuilder.AddOption("720p", "720p"); break;
                        case Quality._Std: menuBuilder.AddOption("High (480p - 720p)", "Std"); break;
                        case Quality._Med: menuBuilder.AddOption("Medium (360p - 480p)", "Med"); break;
                        case Quality._Low: menuBuilder.AddOption("Low (144p - 360p)", "Low"); break;
                    }
                }
                
                components.WithSelectMenu(menuBuilder);
                components.WithButton("<", "MOVIE_SEARCH_BACK", ButtonStyle.Secondary);
                components.WithButton("DOWNLOAD", "MOVIE_SEARCH_DOWNLOAD", ButtonStyle.Success);
                components.WithButton(">", "MOVIE_SEARCH_NEXT", ButtonStyle.Secondary);
                components.WithButton("CANCEL", "MOVIE_SEARCH_CANCEL", ButtonStyle.Danger);

                return (builder, components);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return (null, null);
            }
        }

        public static void StartDownload(this TorrentInfo _torrent)
        {
            Console.WriteLine("Queuing " + _torrent.Title + " for download...");
            Options opt = new Options();
            BitSwarm bitSwarm = new BitSwarm(opt);

            // Step 2: Subscribe events
            bitSwarm.MetadataReceived += BitSwarm_MetadataReceived;
            bitSwarm.StatsUpdated += BitSwarm_StatsUpdated;
            bitSwarm.StatusChanged += BitSwarm_StatusChanged;
            bitSwarm.OnFinishing += BitSwarm_OnFinishing;


            bitSwarm.Open(_torrent.Magnet);
            bitSwarm.Start();

            //bitSwarm.Dispose(); // when done
        }

        private static void BitSwarm_MetadataReceived(object source, BitSwarm.MetadataReceivedArgs e)
        {
            Console.WriteLine("BitSwarm_MetadataReceived:" + e.Torrent.file.name);
        }

        private static void BitSwarm_StatsUpdated(object source, BitSwarm.StatsUpdatedArgs e)
        {
            Console.WriteLine("BitSwarm_StatsUpdated Progress: " + e.Stats.Progress + "%");
            Console.WriteLine("BitSwarm_StatsUpdated ETA: " + TimeSpan.FromSeconds((e.Stats.ETA + e.Stats.AvgETA) / 2).ToString(@"hh\:mm\:ss"));
            Console.WriteLine("BitSwarm_StatsUpdated ETAAVG: " + TimeSpan.FromSeconds(e.Stats.AvgETA).ToString(@"hh\:mm\:ss"));
            Console.WriteLine("BitSwarm_StatsUpdated ETACUR: " + TimeSpan.FromSeconds(e.Stats.ETA).ToString(@"hh\:mm\:ss"));
        }

        private static void BitSwarm_StatusChanged(object source, BitSwarm.StatusChangedArgs e)
        {
            Console.WriteLine("BitSwarm_StatusChanged.Status: " + e.Status);
            Console.WriteLine("BitSwarm_StatusChanged.ErrorMsg: " + e.ErrorMsg);
        }

        private static void BitSwarm_OnFinishing(object source, BitSwarm.FinishingArgs e)
        {
            Console.WriteLine("BitSwarm_OnFinishing");
            // dispose bitSwarm
        }
    }
}