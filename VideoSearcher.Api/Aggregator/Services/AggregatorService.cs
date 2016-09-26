using System.Linq;
using System.Threading.Tasks;
using VideoSearcher.Api.ExternalApi.Interfaces;
using VideoSearcher.Shared;

namespace VideoSearcher.Api.Aggregator.Services
{
    /// <summary>
    /// Service that aggregates data from two services:
    /// MovieInfo (omdbdata api) and Youtube service.
    /// </summary>
    public class AggregatorService
    {
        private readonly IMovieInfoService _movieInfoService;
        private readonly ITrailerSearcher _trailerSearcher;

        public AggregatorService(ITrailerSearcher trailerSearcher, 
                                IMovieInfoService movieInfoService)
        {
            _trailerSearcher = trailerSearcher;
            _movieInfoService = movieInfoService;
        }

        /// <summary>
        /// Gets aggregated video data for query
        /// </summary>
        /// <param name="query">search query</param>
        /// <param name="page">page index</param>
        /// <returns></returns>
        public async Task<SearchMovieResults> GetVideoTrailers(string query, int page)
        {
            // seacrh for movies
            var omdbApiSearchResults = await _movieInfoService.GetMovieInfos(query, page);

            var searchMovieResultsTasks = omdbApiSearchResults.MovieInfos.Select(async mfi =>
                        new SearchMovieResult
                        {
                            MovieFullInfo = mfi,
                            // find trailer for each found movie result
                            TrailerInfo = await _trailerSearcher.GetVideoTrailer(mfi)
                        });
            //waiting to search tasks
            var searchMovieResults = await Task.WhenAll(searchMovieResultsTasks);

            var result = new SearchMovieResults
            {
                Error = omdbApiSearchResults.Error,
                Response = omdbApiSearchResults.Response,
                Results = searchMovieResults.ToList(),
                TotalResults = omdbApiSearchResults.TotalResults,
                CurrentPage = page
            };

            return await Task.FromResult(result);
        }
    }
}