using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;
using VideoLibrary.BusinessEntities.Models.Model;
using System.Collections.Generic;
using PagedList;
using System.Linq;
using System;

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
        public async Task<ActionResult> Index(string title, string orderBy, int? page,string orderDirection = "DESC")
        {
            List<Movie> movies;
            if (!String.IsNullOrEmpty(title))
            {
                movies = await _movieService.GetMovieByTitle(title);
            }
            else
            {
                movies = await _movieService.GetMovies();
            }

            if (orderDirection == "ASC")
            {
                if(orderBy == "genre")
                {
                    movies = movies.OrderBy(m => m.Genre).ToList();
                }
                else if(orderBy == "title")
                {
                    movies = movies.OrderBy(m => m.Title).ToList();
                }
                else if (orderBy == "duration")
                {
                    movies = movies.OrderBy(m => m.Duration).ToList();
                }
                else
                {
                    //Order by Date by default
                    movies = movies.OrderBy(m => m.DateAdded).ToList();
                }

            }
            else
            {
                if (orderBy == "genre")
                {
                    movies = movies.OrderByDescending(m => m.Genre).ToList();
                }
                else if (orderBy == "title")
                {
                    movies = movies.OrderByDescending(m => m.Title).ToList();
                }
                else if (orderBy == "duration")
                {
                    movies = movies.OrderByDescending(m => m.Duration).ToList();
                }
                else
                {
                    movies = movies.OrderByDescending(m => m.DateAdded).ToList();
                }
            }
            int pageNumber = page ?? 1;
            int pageSize = 20;
            ViewBag.page = pageNumber;
            ViewBag.orderBy = orderBy;
            ViewBag.orderDirection = orderDirection;
            ViewBag.movieTitle = title;
            return View(movies.ToPagedList(pageNumber,pageSize));
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
            ViewBag.LeadActorId = new SelectList(await _actorService.GetActors(), "Id", "Name");
            //var actors = await _actorService.GetActors();

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

                TempData["SuccessMessage"] = "Movie Added Successfully!";

                //await _movieService.InsertMovie(movie);
                return RedirectToAction("Index");
            }
            ViewBag.LeadActorId = new SelectList(await _actorService.GetActors(), "Id", "Name");
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
            ViewBag.LeadActorId = new SelectList(await _actorService.GetActors(), "Id", "Name");
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/update")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Duration,LeadActorId,Genre,DateAdded,AddedBy")] Movie movie)
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
        [HttpPost, ActionName("ConfirmDelete")]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/confirm/delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovie(id);

            return RedirectToAction("Index");
        }

    }
}
