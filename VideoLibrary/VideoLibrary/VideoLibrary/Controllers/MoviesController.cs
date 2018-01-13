using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;
using VideoLibrary.BusinessEntities.Models.Model;
using System.Linq;
using System;
using VideoLibrary.BusinessLogic.Repositories.GenreRepository;
using VideoLibrary.Models.ViewModels;

namespace VideoLibrary.Controllers
{
    [RoutePrefix("sineema")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;
        private readonly IGenreRepository _genreRepository;

        public MoviesController(IMovieService movieService, IActorService actorService, IGenreRepository genreRepository)
        {
            _movieService = movieService;
            _actorService = actorService;
            _genreRepository = genreRepository;
        }

        // GET: Movies
        [Route("")]
        public async Task<ActionResult> Index(string sort, string btnAction, string search, string actorFilter, string genreFilter, string yearFilter)
        {
            ViewData["TitleSortParam"] = string.IsNullOrWhiteSpace(sort) ? "title_desc" : string.Empty;
            ViewData["DurationSortParam"] = sort == "duration" ? "duration_desc" : "duration";
            ViewData["GenreSortParam"] = sort == "genre" ? "genre_desc" : "genre";
            ViewData["DateAddedSortParam"] = sort == "date" ? "date_desc" : "date";

            var moviesList = (await _movieService.GetMovies()).Select(m => new MovieListViewModel
            {
                AddedBy = m.AddedBy,
                DateAdded = m.DateAdded.ToString("dd MMM yyyy"),
                Duration = m.Duration??0,
                Genre = m.Genre.Title,
                IsActive = m.IsActive,
                MovieId = m.MovieId,
                Title = m.Title
            });

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
        [Route("{id:guid}/details")]
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _movieService.GetMovieDetails(id));
        }

        // GET: Movies/Create
        [Route("add")]
        public async Task<ActionResult> Create()
        {
            var model = new AddMovieViewModel
            {
                GenreSelectList = (await _genreRepository.GetAllGenres()).Select(g => new SelectListItem
                {
                    Text = g.Title,
                    Value = g.GenreId.ToString()
                })
            };

            return View(model);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("add")]
        public async Task<ActionResult> Create([Bind(Include = "Title,Duration,GenreId,GenreSelectList")] AddMovieViewModel formData)
        {
            if (ModelState.IsValid)
            {

                await _movieService.InsertMovie(new Movie
                {
                    Duration = formData.Duration,
                    GenreId = formData.GenreId,
                    Title = formData.Title,
                    IsActive = true,
                    DateAdded = DateTime.Now,
                    AddedBy = 1
                });
                return RedirectToAction("index");
            }

            return View(formData);
        }

        // GET: Movies/Edit/5
        [Route("{id:guid}/update")]
        public async Task<ActionResult> Edit(Guid id)
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
        [Route("{id:guid}/update")]
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
        [Route("{id:guid}/delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var movie = await _movieService.GetMovieDetails(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("{id:guid}/confirm/delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await _movieService.DeleteMovie(id);

            return RedirectToAction("Index");
        }

    }
}
