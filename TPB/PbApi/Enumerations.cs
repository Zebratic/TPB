using System;

namespace TpbForWindows.PbApi
{
    public enum NavDirection
    {
        /// <summary>
        /// Typically used with a normal search
        /// </summary>
        None,
        /// <summary>
        /// Used to navigate to the next page
        /// </summary>
        Next,
        /// <summary>
        /// Used to navigate to the previous page
        /// </summary>
        Previous
    }

    /// <summary>
    /// Represents the unit of measurement of bytes
    /// </summary>
    public enum DataSizeUnit
    {
        Unknown,
        KB,
        MB,
        GB
    }

    /// <summary>
    /// Represents the various sort modes for search results
    /// (Unsure whether some of these are full sorts or page sorts)
    /// </summary>
    public enum PbSortMode
    {
        /// <summary>
        /// The default sort mode (most relevant?)
        /// </summary>
        Default = 99,
        /// <summary>
        /// Alphabetical sort, lowest valued characters at the top
        /// </summary>
        NameDescending = 1,
        /// <summary>
        /// Alphabetical sort, highest valued characters at the top
        /// </summary>
        NameAscending = 2,
        /// <summary>
        /// The most recently uploaded will be at the top
        /// </summary>
        MostRecent = 3,
        /// <summary>
        /// The oldest uploads will be at the top
        /// </summary>
        LeastRecent = 4,
        /// <summary>
        /// The largest downloads will be at the top
        /// </summary>
        LargestDownload = 5,
        /// <summary>
        /// The smallest downloads will be at the top
        /// </summary>
        SmallestDownload = 6,
        /// <summary>
        /// The most seeded torrents will be at the top
        /// </summary>
        MostSeeded = 7,
        /// <summary>
        /// The least seeded torrents will be at the top
        /// </summary>
        LeastSeeded = 8,
        /// <summary>
        /// The most leeched torrents will be at the top
        /// </summary>
        MostLeeches = 9,
        /// <summary>
        /// The least leeched torrents will be at the top
        /// </summary>
        LeastLeeches = 10,
        /// <summary>
        /// Sorted by uploader name descending (ex. Z-A)
        /// </summary>
        UploaderDescending = 11,
        /// <summary>
        /// Sorted by uploader name ascending (ex. A-Z)
        /// </summary>
        UploaderAscending = 12,
        /// <summary>
        /// Sorted by category and subcategory descending
        /// </summary>
        TypeDescending = 13,
        /// <summary>
        /// Sorted by category and subcategory ascending
        /// </summary>
        TypeAscending = 14
    }

    /// <summary>
    /// Represents any category a torrent can fall under
    /// </summary>
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
