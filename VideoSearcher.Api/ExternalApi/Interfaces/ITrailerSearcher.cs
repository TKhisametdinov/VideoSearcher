using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;
using VideoSearcher.Api.Models;
using VideoSearcher.Shared;

namespace VideoSearcher.Api.ExternalApi.Interfaces
{
    public interface ITrailerSearcher
    {
        Task<List<SearchResult>> GetVideos(string query, int maxResults = 20);

        Task<TrailerInfo> GetVideoTrailer(MovieShortInfo info);
    }
}