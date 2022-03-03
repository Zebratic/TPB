using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTX_NINJA.Zooqle
{
    public class TorrentCleaner
    {
        public static string[] allowedExtensions = { "mp4", "webm", "mkv", "mov", "avi", "wmv", "m4v", "mts", "wmv", "" };
        public static void CleanPath(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);

            // Clean unwanted files
            foreach (FileInfo file in d.GetFiles())
                if (!allowedExtensions.Contains(file.Extension))
                    try { file.Delete(); } catch { Console.WriteLine("Failed to delete: " + file.FullName); }

                
        }
    }
}