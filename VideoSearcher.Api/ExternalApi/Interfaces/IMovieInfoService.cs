using System.Collections.Generic;
using System.Threading.Tasks;
using VideoSearcher.Shared;

namespace VideoSearcher.Api.ExternalApi.Interfaces
{
    public interface IMovieInfoService
    {
        Task<OmdbApiSearchResults> GetMovieInfos(string query, int page);
    }
}