using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using VideoSearcher.Api.ExternalApi.Interfaces;
using VideoSearcher.Api.Models;
using VideoSearcher.Shared;
using VideoSearcher.SharedUtils.Interfaces;

namespace VideoSearcher.Api.ExternalApi.Imdb
{
    /// <summary>
    /// Service that retreives movie data using OmdbAPI
    /// </summary>
    public class MovieInfoService : IMovieInfoService
    {
        private readonly IMovieInfoServiceUrlProvider _movieInfoServiceUrlProvider;
        private readonly IHttpClientHelper _httpClientHelper;

        public MovieInfoService(IMovieInfoServiceUrlProvider movieInfoServiceUrlProvider,
            IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
            _movieInfoServiceUrlProvider = movieInfoServiceUrlProvider;
        }

        /// <summary>
        /// Gets Movie Infos
        /// </summary>
        /// <param name="query">movie title to search</param>
        /// <param name="page">results page index</param>
        /// <returns>found omdb data</returns>
        public async Task<OmdbApiSearchResults> GetMovieInfos(string query, int page)
        {
            // due to omdb api architecture
            // at first we need to search for short information list by title
            var res = new OmdbApiSearchResults();
            
            var url = _movieInfoServiceUrlProvider.GetMovieInfosUrl(query, page);
            var response = await _httpClientHelper.GetAsync(url);
            var responseResult = await response.Content.ReadAsStringAsync();
            var movieInfoSearchResult = JsonConvert.DeserializeObject<OmdbApiSearchResult>(responseResult);

            if (movieInfoSearchResult.TotalResults > 0)
            {
                // for each found movie we are getting full information about it
                var movieInfoTasks = movieInfoSearchResult.Search.Select(x => GetMovieInfo(x.ImdbId));
                var movieInfos = await Task.WhenAll(movieInfoTasks);
                res.MovieInfos = movieInfos;
            }
            res.TotalResults = movieInfoSearchResult.TotalResults;
            res.Response = movieInfoSearchResult.Response;
            res.Error = movieInfoSearchResult.Error;

            return res;
        }

        /// <summary>
        /// Gets movie full information 
        /// </summary>
        /// <param name="imdbId">id of movie</param>
        /// <returns>movie full information</returns>
        public async Task<MovieFullInfo> GetMovieInfo(string imdbId)
        {
            var urlinfo = _movieInfoServiceUrlProvider.GetMovieInfoByIdUrl(imdbId);
            var response = await _httpClientHelper.GetAsync(urlinfo);
            var result = await response.Content.ReadAsStringAsync();
            var deserializedResult = JsonConvert.DeserializeObject<MovieFullInfo>(result);
            return deserializedResult;
        }
    }
}