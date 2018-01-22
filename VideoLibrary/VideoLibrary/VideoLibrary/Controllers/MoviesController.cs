using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;
using VideoLibrary.BusinessEntities.Models.Model;

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
        public async Task<ActionResult> Index()
        {
            return View(await _movieService.GetMovies());
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

            ViewBag.ActorId = new SelectList(await _actorService.GetActors(), "Id", "Name");
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        [Route("{id:int}/partial_edit")]
        public async Task<ActionResult> Partial_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ActorId = new SelectList(await _actorService.GetActors(), "Id", "Name");
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return PartialView("Edit",movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/update")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Duration,Genre,LeadActorId")] Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                Movie oldMovie = await _movieService.GetMovie(newMovie.Id);

                await _movieService.DeleteMovie(oldMovie.Id);
                await _actorService.DeleteActor(oldMovie.LeadActorId);

                oldMovie.LeadActorId = newMovie.LeadActorId;
                oldMovie.Title = newMovie.Title;
                oldMovie.Duration = newMovie.Duration;
                oldMovie.Genre = newMovie.Genre;

                await _movieService.InsertMovie(oldMovie);
                return RedirectToAction("Index");
            }

            return View(newMovie);
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
        [Route("{id:int}/delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovie(id);

            return RedirectToAction("Index");
        }

    }
}
