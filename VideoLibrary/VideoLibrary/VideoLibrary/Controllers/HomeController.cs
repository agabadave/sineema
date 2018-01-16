using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;

namespace VideoLibrary.Controllers
{
    public class HomeController : Controller
    {
        LibraryContext context = new LibraryContext();

        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;

        public HomeController(IMovieService movieService, IActorService actorService)
        {
            _movieService = movieService;
            _actorService = actorService;
        }

        public ActionResult Index()
        {
            var actors =  _movieService.GetMovies();


            ViewBag.Movies = 100;
            ViewBag.Actors = 400;

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