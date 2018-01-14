using System.Web.Mvc;
using DotNet.Highcharts;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;
using VideoLibrary.BusinessEntities.Models.Model;
using DotNet.Highcharts.Attributes;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Threading.Tasks;

namespace VideoLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;

        public HomeController(IMovieService movieService, IActorService actorService)
        {
            _movieService = movieService;
            _actorService = actorService;
        }
        public async Task<ActionResult> Index()
        {
            Highcharts pieChart = new Highcharts("MoviesPerGenre");

            ViewData["RecentMovies"] = _movieService.GetRecentMovies(10);
            ViewData["CountPerGenre"] = _movieService.GetCountPerGenre();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
} 