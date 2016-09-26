using Google.Apis.YouTube.v3.Data;
using System.Collections.Generic;

namespace VideoSearcher.Api.Models
{
    public class YouTubeSearchResult
    {
        public IList<SearchResult> YouTubeVideos { get; set; }
        public IList<SearchResult> YouTubeChannels { get; set; }
        public IList<SearchResult> YouTubePlaylists { get; set; }
    }
}