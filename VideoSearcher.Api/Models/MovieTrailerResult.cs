using System.Collections.Generic;
using VideoSearcher.Shared;

namespace VideoSearcher.Api.Models
{
    public class MovieTrailerResult
    {
        public YouTubeSearchResult YouTubeSearchResult { get; set; }
        public IEnumerable<MovieFullInfo> OmdbApiSearchResult { get; set; }
    }
}