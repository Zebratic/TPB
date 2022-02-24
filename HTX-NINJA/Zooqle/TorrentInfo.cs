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
        public string Magnet { get; set; }
        public int Seeders { get; set; }
        public int Leechers { get; set; }
        public string FileSize { get; set; }
        public string SizeUnit { get; set; }
        public Quality Quality { get; set; }

        public TorrentInfo(string _title = "", string _magnet = "", int _seeders = 0, int _leechers = 0, string _filesize = "", string _sizeunit = "", Quality _quality = Quality._Undefined)
        {
            Title = _title;
            Magnet = _magnet;
            Seeders = _seeders;
            Leechers = _leechers;
            FileSize = _filesize;
            SizeUnit = _sizeunit;
            Quality = _quality;
        }
    }

    public class MovieInfo
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string CoverURL { get; set; }
        public int TorrentsAvailable { get; set; }
        public MovieInfo(string _title, string _url, string _coverurl, int _torrentsavailable)
        {
            Title = _title;
            URL = _url;
            CoverURL = _coverurl;
            TorrentsAvailable = _torrentsavailable;
        }
    }

    public enum Quality
    {
        _Undefined,
        _3D,
        _4K,
        _1080P,
        _720P,
        _Std,
        _Med,
        _Low,
    }
}
