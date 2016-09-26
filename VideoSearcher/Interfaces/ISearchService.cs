using System.Threading.Tasks;
using VideoSearcher.Shared;

namespace VideoSearcher.Interfaces
{
    public interface ISearchService
    {
        Task<SearchMovieResults> GetMoviesResults(string query, int page);
    }
}