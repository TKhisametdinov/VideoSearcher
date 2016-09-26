using System.Collections.Generic;

namespace VideoSearcher.Shared
{
    public class OmdbApiSearchResults
    {
        public IList<MovieFullInfo> MovieInfos { get; set; }

        public int TotalResults { get; set; }

        public bool Response { get; set; }

        public string Error { get; set; }
    }
}
