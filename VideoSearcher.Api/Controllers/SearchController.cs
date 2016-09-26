using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Tracing;
using VideoSearcher.Api.Aggregator.Services;
using VideoSearcher.Shared;
using WebApi.OutputCache.V2;

namespace VideoSearcher.Api.Controllers
{
    /// <summary>
    /// Controller that handles retrieving aggregated video data
    /// </summary>
    public class SearchController : ApiController
    {
        private readonly AggregatorService _aggregatorService;
        private readonly ITraceWriter _traceWriter;

        public SearchController(ITraceWriter traceWriter, AggregatorService aggregatorService)
        {
            _aggregatorService = aggregatorService;
            _traceWriter = traceWriter;
        }

        /// <summary>
        /// Retrieves aggreagted video data 
        /// according requested query message and page index
        /// </summary>
        /// <param name="query">search query message</param>
        /// <param name="page">page index of results</param>
        /// <returns></returns>
        [CacheOutput(ClientTimeSpan = 3600, ServerTimeSpan = 3600)]
        public async Task<SearchMovieResults> Get(string query, int page = 1)
        {
            try
            {
                return await _aggregatorService.GetVideoTrailers(query, page);
            }
            catch (Exception ex)
            {
                _traceWriter.Error(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, ex.Message.ToString());
            }
            return await Task.FromResult(default(SearchMovieResults));
        }
    }
}
