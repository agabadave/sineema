using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;
using VideoLibrary.BusinessEntities.Models.Model;
using System.Linq;

namespace VideoLibrary.Controllers
{
    [RoutePrefix("sineema")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;

        public MoviesController(IMovieService movieService, IActorService actorService)
        {
            _movieService = movieService;
            _actorService = actorService;
        }

        // GET: Movies
        [Route("")]
        public async Task<ActionResult> Index(string sort, string btnAction, string search, string actorFilter, string genreFilter, string yearFilter)
        {
            ViewData["TitleSortParam"] = string.IsNullOrWhiteSpace(sort) ? "title_desc" : string.Empty;
            ViewData["DurationSortParam"] = sort == "duration" ? "duration_desc" : "duration";
            ViewData["GenreSortParam"] = sort == "genre" ? "genre_desc" : "genre";
            ViewData["DateAddedSortParam"] = sort == "date" ? "date_desc" : "date";

            var moviesList = await _movieService.GetMovies();

            switch (btnAction)
            {
                case "search":
                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        moviesList = moviesList.Where(l => l.Title.ToLower().Contains(search.ToLower())).ToList();
                    }
                    break;
                case "filter":
                    break;
            }

            switch (sort)
            {
                case "title_desc":
                    ViewData["SortParam"] = "title";
                    moviesList = moviesList.OrderByDescending(l => l.Title).ToList();
                    break;
                case "duration":
                    ViewData["SortParam"] = "duration";
                    moviesList = moviesList.OrderBy(l => l.Duration).ToList();
                    break;
                case "duration_desc":
                    ViewData["SortParam"] = "duration";
                    moviesList = moviesList.OrderByDescending(l => l.Duration).ToList();
                    break;
                case "genre":
                    ViewData["SortParam"] = "genre";
                    moviesList = moviesList.OrderBy(l => l.Genre).ToList();
                    break;
                case "genre_desc":
                    ViewData["SortParam"] = "genre";
                    moviesList = moviesList.OrderByDescending(l => l.Genre).ToList();
                    break;
                case "date":
                    ViewData["SortParam"] = "date";
                    moviesList = moviesList.OrderBy(l => l.DateAdded).ToList();
                    break;
                case "date_desc":
                    ViewData["SortParam"] = "date";
                    moviesList = moviesList.OrderByDescending(l => l.DateAdded).ToList();
                    break;
                default:
                    ViewData["SortParam"] = "title";
                    moviesList = moviesList.OrderBy(l => l.Title).ToList();
                    break;
            }

            return View(moviesList);
        }

        // GET: Movies/Details/5
        [Route("{id:int}/details")]
        public async Task<ActionResult> Details(int? id)
        {
            return View(await _movieService.GetMovieDetails(id));
        }

        // GET: Movies/Create
        [Route("add")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActorId = new SelectList(await _actorService.GetActors(), "Id", "Name");
            var actors = await _actorService.GetActors();

            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("add")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Duration,Genre,LeadActorId")] Movie movie)
        {
            if (ModelState.IsValid)
            {

                await _movieService.InsertMovie(movie);



                //await _movieService.InsertMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        [Route("{id:int}/update")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/update")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Duration,ActorId,Genre,DateAdded,AddedBy")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.UpdateMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Delete/5
        [Route("{id:int}/delete")]
        public async Task<ActionResult> Delete(int? id)
        {
            var movie = await _movieService.GetMovie(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/confirm/delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovie(id);

            return RedirectToAction("Index");
        }

    }
}
