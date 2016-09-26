using VideoSearcher.SharedUtils.Interfaces;

namespace VideoSearcher.Api.ExternalApi.Imdb
{
    /// <summary>
    /// Omdb web api requests url provider 
    /// </summary>
    public class MovieInfoServiceUrlProvider : IMovieInfoServiceUrlProvider
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
        /// Builds url for getting movie info by id
        /// </summary>
        /// <param name="imdbId">movie id</param>
        /// <returns>url</returns>
        public string GetMovieInfoByIdUrl(string imdbId)
        {
            return $"{_baseUrl}?i={imdbId}&plot=full&r=json";
        }

        /// <summary>
        /// Builds url for getting full movies info by search query
        /// Supports pagination, with page index
        /// </summary>
        /// <param name="query">search query</param>
        /// <param name="page">page index</param>
        /// <returns>movie results from omdb api</returns>
        public string GetMovieInfosUrl(string query, int page)
        {
            return $"{_baseUrl}?s={query}&page={page}";
        }
    }
}