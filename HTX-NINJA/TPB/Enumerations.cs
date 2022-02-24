using System;

namespace HTX_NINJA.TPB
{
    public enum NavDirection
    {
        None,
        Next,
        Previous
    }

    public enum DataSizeUnit
    {
        Unknown,
        KB,
        MB,
        GB
    }
    public enum PbSortMode
    {
        Default = 99,
        NameDescending = 1,
        NameAscending = 2,
        MostRecent = 3,
        LeastRecent = 4,
        LargestDownload = 5,
        SmallestDownload = 6,
        MostSeeded = 7,
        LeastSeeded = 8,
        MostLeeches = 9,
        LeastLeeches = 10,
        UploaderDescending = 11,
        UploaderAscending = 12,
        TypeDescending = 13,
        TypeAscending = 14
    }

    [Flags]
    public enum TorrentCategory
    {
        None = 0,
        Audio = 1,
        Video = 2,
        Applications = 4,
        Games = 8,
        Porn = 16,
        Other = 32
    }
}