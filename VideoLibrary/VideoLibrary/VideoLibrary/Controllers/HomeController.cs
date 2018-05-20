using System.Collections.Generic;
using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;

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
        public ActionResult Index()
        {
            List<string[]> genres = new List<string[]>();
            genres.Add(new string[] { "Local","20"});
            genres.Add(new string[] { "Nigerian", "24" });
            ViewBag.Genres = _movieService.GetDistributionByGenre();
            ViewBag.Recent = _movieService.GetRecent();
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