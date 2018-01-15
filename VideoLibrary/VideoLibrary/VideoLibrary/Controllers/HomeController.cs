using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Repositories.BorrowedMovieRepository;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;
using VideoLibrary.Models.ViewModels;

namespace VideoLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBorrowedMovieRepository _borrowedMovieRepository;
        private readonly IMovieRepository _movieRepository;

        public HomeController(IBorrowedMovieRepository borrowedMovieRepository, IMovieRepository movieRepository)
        {
            _borrowedMovieRepository = borrowedMovieRepository;
            _movieRepository = movieRepository;
        }

        public async Task<ActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                BorrowedMovies = (await _borrowedMovieRepository.GetAllBorrowedMovies().ToListAsync()).Count,
                MoviesCount = (await _movieRepository.GetAllMovies().ToListAsync()).Count
            };

            return View(model);
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