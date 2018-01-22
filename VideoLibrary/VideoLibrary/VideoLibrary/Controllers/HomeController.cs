using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Repositories.ActorRepository;
using VideoLibrary.BusinessLogic.Repositories.ClientRepository;
using VideoLibrary.BusinessLogic.Repositories.MovieActorRepository;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;

namespace VideoLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IMovieRepository movieRepo = new MovieRepository();
            IMovieActorRepository movieActorsRepo = new MovieActorRepository();
            IActorRepository actorRepo = new ActorRepository();
            IClientRepository clientsRepo = new ClientRepository();

            int countOfMovies = movieRepo.CountMovies();
            int countOfMovieActors = movieActorsRepo.GetCount();
            int countOfActors = actorRepo.GetCount();
            int countOfClients = clientsRepo.GetCount();

            ViewBag.countOfMovies = countOfMovies;
            ViewBag.countOfMovieActors = countOfMovieActors;
            ViewBag.countOfActors = countOfActors;
            ViewBag.countOfClients = countOfClients;

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