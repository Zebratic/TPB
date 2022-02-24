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
        public SocketCommandContext Context { get; set; }
        public IUserMessage Message { get; set; }
        public string Term { get; set; }
        public List<MovieInfo> Results { get; set; }
        public int CurrentIndex { get; set; }
        public SearchRequest(SocketCommandContext _context)
        {
            Context = _context;
            CurrentIndex = 0;
            Results = new List<MovieInfo>();
        }
    }

    public static class SearchRequestExtensions
    {
        public static void SearchForTorrent(this SearchRequest request, string term)
        {
            request.Term = term;

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string html = wc.DownloadString(request.BaseURL + "search?q=" + term.Replace(" ", "+"));

                string[] movies = html.Split(new[] { "<li title=\"", }, StringSplitOptions.None);

                for (int i = 1; i < movies.Length - 1; i++)
                {
                    string title = movies[i].Split(new[] { "\">" }, StringSplitOptions.None)[0];
                    string url = request.BaseURL + movies[i].Split(new[] { "href=\"/" }, StringSplitOptions.None)[1].Split(new[] { "\">" }, StringSplitOptions.None)[0];
                    string coverurl = "";
                    try { coverurl = request.BaseURL + movies[i].Split(new[] { "src=\"/" }, StringSplitOptions.None)[1].Split(new[] { "\">" }, StringSplitOptions.None)[0].Replace("2.jpg", "0.jpg"); } catch { }
                    string torrentsavailable_string = movies[i].Split(new[] { "\"></i> " }, StringSplitOptions.None)[1].Split(new[] { " torrents" }, StringSplitOptions.None)[0];
                    int torrentsavailable = Convert.ToInt32(torrentsavailable_string);
                    request.Results.Add(new MovieInfo(title, url, coverurl, torrentsavailable));
                }

            }
        }

        public static void NextTorrent(this SearchRequest request, bool next)
        {
            if (next)
            {
                request.CurrentIndex++;
                //request.Message.ModifyAsync(); // New embed
            }
            else
            {
                request.CurrentIndex--;
                //request.Message.ModifyAsync(); // New embed
            }
        }
    }
}