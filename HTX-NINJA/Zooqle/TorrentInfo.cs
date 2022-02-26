using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTX_NINJA.Zooqle
{
    public class TorrentInfo
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string Magnet { get; set; }
        public int Seeders { get; set; }
        public int Leechers { get; set; }
        public string UploadDate { get; set; }
        public string FileSize { get; set; }
        public Quality Quality { get; set; }

        public TorrentInfo(string _title = "", string _url = "", string _magnet = "", int _seeders = 0, int _leechers = 0, string _uploaddate = "", string _filesize = "", Quality _quality = Quality._Undefined)
        {
            Title = _title;
            URL = _url;
            Magnet = _magnet;
            Seeders = _seeders;
            Leechers = _leechers;
            UploadDate = _uploaddate;
            FileSize = _filesize;
            Quality = _quality;
        }
    }

    public class MovieInfo
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string CoverURL { get; set; }
        public int TorrentsAvailable { get; set; }
        public List<TorrentInfo> Torrents = new List<TorrentInfo>();
        public List<Quality> Qualities = new List<Quality>();
        public Quality SelectedQuality { get; set; }
        public MovieInfo(string _title, string _url, string _coverurl, int _torrentsavailable)
        {
            Title = _title;
            URL = _url;
            CoverURL = _coverurl;
            TorrentsAvailable = _torrentsavailable;
            SelectedQuality = Quality._Undefined;
        }

        public MovieInfo()
        {

        }
    }

    public enum Quality
    {
        _Undefined,
        _3D,
        _Ultra,
        _1080p,
        _720p,
        _Std,
        _Med,
        _Low,
        _Unknown,
    }

    public static class QualityExtensions
    {
        public static string GetQualityString(this Quality quality)
        {
            switch (quality)
            {
                case Quality._Undefined: return "Undefined";
                case Quality._3D: return "3D";
                case Quality._Ultra: return "2160p";
                case Quality._1080p: return "1080p";
                case Quality._720p: return "720p";
                case Quality._Std: return "High";
                case Quality._Med: return "Medium";
                case Quality._Low: return "Low";
                default: return "Unknown";
            }
        }
    }
}
