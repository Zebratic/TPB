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
        public static string[] allowedExtensions = { "mp4", "webm", "mkv", "mov", "avi", "wmv", "m4v", "mts", "wmv", "srt", "ssc" };
        public static void CleanFiles(string path)
        {
            // Clean unwanted files
            foreach (string file in GetAllFiles(path))
            {
                if (!allowedExtensions.Contains(Path.GetExtension(file).Replace(".", "")))
                {
                    Console.WriteLine("DELETING: " + file);
                    try { File.Delete(file); } catch (Exception ex) { Console.WriteLine("Failed to delete: " + file + "\n" + ex); }
                }
            }
        }

        public static void MoveAndRenameFiles(string path, string newpath, string name)
        {
            // Create directories if missing
            Directory.CreateDirectory(newpath);

            // Move and rename files
            foreach (string file in GetAllFiles(path))
            {
                string tempname = name;
            retry:
                try { File.Move(file, $"{newpath}\\{tempname}{Path.GetExtension(file)}"); }
                catch
                {
                    tempname = tempname + ".";
                    goto retry;
                }
            }
        }

        private static List<string> GetAllFiles(string dir)
        {
            List<string> files = new List<string>();
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                    files.Add(f);

                foreach (string d in Directory.GetDirectories(dir))
                    files.AddRange(GetAllFiles(d));
            }
            catch (Exception ex) { Console.WriteLine(ex); }

            return files;
        }
    }
}