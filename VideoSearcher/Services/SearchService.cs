using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using VideoSearcher.Interfaces;
using VideoSearcher.Shared;
using VideoSearcher.SharedUtils.Interfaces;

namespace VideoSearcher.Services
{
    /// <summary>
    /// Service for movie search, including possible trailers
    /// </summary>
    public class SearchService : ISearchService
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IUrlProvider _movieInfoServiceUrlProvider;

        public SearchService(IHttpClientHelper httpClientHelper,
            IUrlProvider movieInfoServiceUrlProvider)
        {
            _httpClientHelper = httpClientHelper;
            _movieInfoServiceUrlProvider = movieInfoServiceUrlProvider;
        }

        /// <summary>
        /// Gets movies according query request
        /// Supports pagination through page index
        /// </summary>
        /// <param name="query">query request</param>
        /// <param name="page">page index</param>
        /// <returns></returns>
        public async Task<SearchMovieResults> GetMoviesResults(string query, int page)
        {
            try
            {
                var url = _movieInfoServiceUrlProvider.GetMovieInfosUrl(query, page);
                var response = await _httpClientHelper.GetAsync(url);
                var movieResultsString = await response.Content.ReadAsStringAsync();
                var movieResults = JsonConvert.DeserializeObject<SearchMovieResults>(movieResultsString);
                return movieResults;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return await Task.FromResult(default(SearchMovieResults));
        }
    }
}