using Google.Apis.YouTube.v3.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoSearcher.Api.ExternalApi.Interfaces;
using VideoSearcher.Shared;
using Thumbnail = VideoSearcher.Shared.Thumbnail;

namespace VideoSearcher.Api.ExternalApi.Youtube.Services
{
    /// <summary>
    /// Service that helps with searching youtube video data
    /// </summary>
    public class YouTubeTrailerSearcher : ITrailerSearcher
    {
        private readonly YouTubeServiceProvider _provider;

        public YouTubeTrailerSearcher(YouTubeServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Searches for youtube video data by search query
        /// </summary>
        /// <param name="query">search query</param>
        /// <param name="maxResults">max results in response</param>
        /// <returns>list of youtube results</returns>
        public async Task<List<SearchResult>> GetVideos(string query, int maxResults = 1)
        {
            var searchListRequest = _provider.Service.Search.List("snippet");
            searchListRequest.Q = query;
            searchListRequest.MaxResults = maxResults;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            var result = new List<SearchResult>(searchListResponse.Items);

            return result;
        }

        /// <summary>
        /// Searches for youtube video trailer using title from omdb movie info
        /// </summary>
        /// <param name="info">omdb movie info</param>
        /// <returns>Trailer information</returns>
        public async Task<TrailerInfo> GetVideoTrailer(MovieShortInfo info)
        {
            // adding 'trailer' word to query for searching possible trailers first
            var queryForTrailer = $"{info.Title} {info.Year} trailer";

            var searchresult = await GetVideos(queryForTrailer);

            // Call the search.list method to retrieve results matching the specified query term.
            var firstResult = searchresult.FirstOrDefault();
            if (firstResult != null)
            {
                return ParseTrailerInfo(firstResult);
            }

            return await Task.FromResult(default(TrailerInfo));
        }

        /// <summary>
        /// Parses youtube search result to TrailerInfo data transfer object
        /// </summary>
        /// <param name="searchresult"></param>
        /// <returns>TrailerInfo DTO</returns>
        private TrailerInfo ParseTrailerInfo(SearchResult searchresult)
        {
            return new TrailerInfo
            {
                Title = searchresult.Snippet.Title,
                Description = searchresult.Snippet.Description,
                PublishedAtRaw = searchresult.Snippet.PublishedAtRaw,
                Url = searchresult.Id.VideoId,
                Thumbnails = new Shared.ThumbnailDetails
                {
                    Default = ParseFromGoogleThumbnail(searchresult.Snippet.Thumbnails.Default__),
                    Medium = ParseFromGoogleThumbnail(searchresult.Snippet.Thumbnails.Medium),
                    Standard = ParseFromGoogleThumbnail(searchresult.Snippet.Thumbnails.Standard),
                    High = ParseFromGoogleThumbnail(searchresult.Snippet.Thumbnails.High),
                    Maxres = ParseFromGoogleThumbnail(searchresult.Snippet.Thumbnails.Maxres),
                }
            };
        }

        /// <summary>
        /// Parses Youtube Thumbnail
        /// </summary>
        /// <param name="thumbnail">Youtube Thumbnail</param>
        /// <returns>Thumbnail DTO</returns>
        private Thumbnail ParseFromGoogleThumbnail(Google.Apis.YouTube.v3.Data.Thumbnail thumbnail)
        {
            if (thumbnail == null)
            {
                return null;
            }

            return new Thumbnail { Url = thumbnail.Url, Height = thumbnail.Height, Width = thumbnail.Width };
        }
    }
}