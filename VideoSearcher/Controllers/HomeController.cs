using System.Threading.Tasks;
using System.Web.Mvc;
using VideoSearcher.Interfaces;

namespace VideoSearcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService _searchService;

        public HomeController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Search(string query, int page)
        {
            var movies = await _searchService.GetMoviesResults(query, page);

            return PartialView(movies);
        }
    }
}