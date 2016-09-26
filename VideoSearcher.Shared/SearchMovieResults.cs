using System.Collections.Generic;

namespace VideoSearcher.Shared
{
    public class SearchMovieResults
    {
        public List<SearchMovieResult> Results { get; set; }

        public int TotalResults { get; set; }

        public bool Response { get; set; }

        public string Error { get; set; }

        public int CurrentPage { get; set; }
    }
}