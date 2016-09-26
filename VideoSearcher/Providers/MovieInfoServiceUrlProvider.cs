using VideoSearcher.SharedUtils.Interfaces;

namespace VideoSearcher.Providers
{
    /// <summary>
    /// Search web api requests url provider 
    /// </summary>
    public class MovieInfoServiceUrlProvider : IUrlProvider
    {
        private readonly string _baseUrl;

        public MovieInfoServiceUrlProvider(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public string GetBaseServiceUrl()
        {
            return _baseUrl;
        }

        /// <summary>
        /// Builds url for retrieving movies from search api
        /// </summary>
        /// <param name="query">search query</param>
        /// <param name="page">page index of results</param>
        /// <returns>search api url</returns>
        public string GetMovieInfosUrl(string query, int page)
        {
            return $"{_baseUrl}/api/Search/?query={query}&page={page}";
        }
    }
}