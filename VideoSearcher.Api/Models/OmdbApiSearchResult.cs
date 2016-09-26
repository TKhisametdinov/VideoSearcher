using System.Collections.Generic;
using VideoSearcher.Shared;

namespace VideoSearcher.Api.Models
{
    public class OmdbApiSearchResult
    {
        public List<MovieShortInfo> Search { get; set; }

        public int TotalResults { get; set; }

        public bool Response { get; set; }

        public string Error { get; set; }
    }
}