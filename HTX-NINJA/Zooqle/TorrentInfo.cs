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
        public string Description { get; set; }
        public string Magnet { get; set; }
        public string CoverURL { get; set; }
        public string FileSize { get; set; }
        public string SizeUnit { get; set; }
        public string SizeUnit { get; set; }

        public TorrentInfo(string _title, string _description, string _magnet, string _coverurl, string _filesize, string _sizeunit)
        {

        }
    }
}
