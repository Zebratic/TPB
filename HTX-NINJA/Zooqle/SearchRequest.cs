using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Net;

namespace HTX_NINJA.Zooqle
{
    public class GlobalRequests
    {
        public static List<SearchRequest> SearchRequests = new List<SearchRequest>();
    }

    public class SearchRequest
    {
        public string BaseURL = "https://zooqle.com/";
        public SocketUser User { get; set; }
        public IUserMessage Message { get; set; }
        public string Term { get; set; }
        public List<MovieInfo> Results { get; set; }
        public int CurrentIndex { get; set; }
        public SearchRequest(SocketUser _user)
        {
            User = _user;
            CurrentIndex = 0;
            Results = new List<MovieInfo>();
        }

        public static SearchRequest GetRequestFromUser(SocketUser _user) => GlobalRequests.SearchRequests.Find(x => x.User.Id == _user.Id);
    }

    public static class SearchRequestExtensions
    {
        public static void SearchForTorrent(this SearchRequest _request, string _term)
        {
            _request.Term = _term;

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string html = wc.DownloadString(_request.BaseURL + "search?q=" + _term.Replace(" ", "+"));

                string[] movies = html.Split(new[] { "<li title=\"", }, StringSplitOptions.None);

                for (int i = 1; i < movies.Length - 1; i++)
                {
                    MovieInfo movie = new MovieInfo();
                    movie.Title = movies[i].Split(new[] { "\">" }, StringSplitOptions.None)[0];
                    movie.URL = _request.BaseURL + movies[i].Split(new[] { "href=\"/" }, StringSplitOptions.None)[1].Split(new[] { "\">" }, StringSplitOptions.None)[0];
                    try { movie.CoverURL = _request.BaseURL + movies[i].Split(new[] { "src=\"/" }, StringSplitOptions.None)[1].Split(new[] { "\">" }, StringSplitOptions.None)[0].Replace("2.jpg", "0.jpg"); } catch { }
                    string torrentsavailable_string = movies[i].Split(new[] { "\"></i> " }, StringSplitOptions.None)[1].Split(new[] { " torrents" }, StringSplitOptions.None)[0];
                    movie.TorrentsAvailable = -1;
                    try { movie.TorrentsAvailable = Convert.ToInt32(torrentsavailable_string); } catch { }
                    try { movie.GetDetailedInfo(); } catch { }
                    if (movie.TorrentsAvailable > 0 || movie.TorrentsAvailable == -1)
                        _request.Results.Add(movie);
                }
            }
        }

        public static void GetDetailedInfo(this MovieInfo _movie)
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
                            try
                            {
                                string quality = qualities[i].Split(new[] { "\"></i> " }, StringSplitOptions.None)[1].Split(new[] { "</span>" }, StringSplitOptions.None)[0];
                                Console.WriteLine(_movie.URL + " | " + quality);
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
                            catch { }
                            
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
            _request.CurrentIndex++;
            if (_request.CurrentIndex == _request.Results.Count)
                _request.CurrentIndex = 0;
        }

        public static void LastResult(this SearchRequest _request)
        {
            _request.CurrentIndex--;
            if (_request.CurrentIndex < 0)
                _request.CurrentIndex = _request.Results.Count - 1;
        }

        public static MovieInfo GetCurrentMovie(this SearchRequest _request) => _request.Results[_request.CurrentIndex];

        public static (EmbedBuilder, ComponentBuilder) GetResult(this SearchRequest _request)
        {
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
    }
}