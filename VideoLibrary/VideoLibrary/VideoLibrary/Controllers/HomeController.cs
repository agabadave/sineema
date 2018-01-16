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
using System.Collections.Generic;

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
            var countPerGenre = _movieService.GetCountPerGenre();
            var movieCount = 0;
            foreach (var item in countPerGenre)
            {
                movieCount += item.Count;
            }
            var movieShare = new List<object[]>();

            foreach (var item in countPerGenre)
            {
                movieShare.Add(new object[] { item.Title,(item.Count * 100 / movieCount) });
            }
            Highcharts pieChart = new Highcharts("MoviesPerGenre");
            pieChart.SetSeries(new Series
            {
                Type = ChartTypes.Pie,
                Name = "Movie Share Per Genre",
                Data = new Data(movieShare.ToArray())
            });
            pieChart.SetTitle(new Title { Text = "Movie Distribution Per Genre" });
            ViewData["RecentMovies"] = _movieService.GetRecentMovies(5);
            ViewData["CountPerGenreChart"] = pieChart;

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