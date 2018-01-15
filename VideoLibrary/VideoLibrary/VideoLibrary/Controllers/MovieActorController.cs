using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.MovieActorRepository;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.Models.ViewModels;

namespace VideoLibrary.Controllers
{
    public class MovieActorController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IMovieActorRepository _movieActorRepository;

        public MovieActorController(IActorService actorService, IMovieActorRepository movieActorRepository)
        {
            _actorService = actorService;
            _movieActorRepository = movieActorRepository;
        }

        [Route("movies/{movie:guid}/actors/{movieactor:guid}/edit")]
        public async Task<ActionResult> EditMovieActor(Guid movie, Guid movieactor)
        {
            var movieActor = (await _movieActorRepository.GetMovieActorsAsync(movie)).FirstOrDefault(ma => ma.MovieActorId == movieactor);

            if (movieActor == null)
            {
                return HttpNotFound();
            }

            var model = new EditMovieActorViewModel
            {
                ActorFullname = movieActor.Actor.Fullname,
                LeadActor = bool.Parse(movieActor.LeadActor.ToString()),
                MovieActorId = movieActor.MovieActorId,
                Role = movieActor.Role,
                MovieId = Guid.Parse(movieActor.MovieId.ToString()),
                ActorId = Guid.Parse(movieActor.ActorId.ToString()),
                MovieTitle = movieActor.Movie.Title
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("movies/{movie:guid}/actors/{actor:guid}/edit")]
        public async Task<ActionResult> EditMovieActor(EditMovieActorViewModel formData)
        {
            if (ModelState.IsValid)
            {
                await _movieActorRepository.UpdateMovieActorAsync(new MovieActor
                {
                    LeadActor = formData.LeadActor,
                    MovieActorId = formData.MovieActorId,
                    Role = formData.Role
                });

                return RedirectToAction("movieactors", new { controller = "movies", id = formData.MovieId });
            }

            return View(formData);
        }
    }
}