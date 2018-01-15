using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using System.Linq;
using VideoLibrary.Models.ViewModels;
using System;
using VideoLibrary.BusinessLogic.Repositories.GenderRepository;
using VideoLibrary.BusinessLogic.Repositories.GenreRepository;

namespace VideoLibrary.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IGenderRepository _genderRepository;
        private readonly IGenreRepository _genreRepository;

        public ActorsController(IActorService actorService, IGenderRepository genderRepository, IGenreRepository genreRepository)
        {
            _actorService = actorService;
            _genderRepository = genderRepository;
            _genreRepository = genreRepository;
        }

        // GET: Actors
        public async Task<ActionResult> Index()
        {
            var model = (await _actorService.GetActorsAsync())
                .Select(actor => new ActorViewModel
                {
                    ActorId = actor.ActorId,
                    DateOfBirth = actor.DateOfBirth == null ? string.Empty : DateTime.Parse(actor.DateOfBirth.ToString()).ToString("dd/MM/yyyy"),
                    Fullname = actor.Fullname,
                    Gender = actor.Gender.Description,
                    GenderId = actor.GenderId ?? Guid.Empty,
                    Genre = actor.Genre.Title,
                    GenreId = actor.GenreId ?? Guid.Empty
                });

            return View(model);
        }

        public async Task<ActionResult> Add()
        {
            var model = new AddActorViewModel
            {
                GenderSelectList = (await _genderRepository.GetAllGenders()).Select(gender => new SelectListItem
                {
                    Text = gender.Description,
                    Value = gender.GenderId.ToString()
                }),
                GenreSelectList = (await _genreRepository.GetAllGenres()).Select(genre => new SelectListItem
                {
                    Text = genre.Title,
                    Value = genre.GenreId.ToString()
                })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(AddActorViewModel formData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _actorService.SaveActorAsync(new Actor
                    {
                        ActorId = Guid.NewGuid(),
                        AddedBy = 1,
                        DateAdded = DateTime.Now,
                        DateOfBirth = formData.DateOfBirth,
                        Firstname = formData.Firstname,
                        GenderId = formData.GenderId,
                        GenreId = formData.GenreId,
                        IsActive = true,
                        Lastname = formData.Lastname
                    });

                    return RedirectToAction("index");
                }
                catch (Exception error)
                {
                    ModelState.AddModelError("", "Error: Failed to add new actor.");
                    return View(formData);
                }
            }

            formData.GenderSelectList = (await _genderRepository.GetAllGenders()).Select(gender => new SelectListItem
            {
                Text = gender.Description,
                Value = gender.GenderId.ToString()
            });

            formData.GenreSelectList = (await _genreRepository.GetAllGenres()).Select(genre => new SelectListItem
            {
                Text = genre.Title,
                Value = genre.GenreId.ToString()
            });

            return View(formData);
        }

        [Route("actors/{id:guid}")]
        public async Task<ActionResult> Details(Guid id)
        {
            var actor = await _actorService.GetActorByIdAsync(id);

            var model = new ActorDetailsViewModel
            {
                ActorId = actor.ActorId,
                DateOfBirth = actor.DateOfBirth,
                Firstname = actor.Firstname,
                GenderId = actor.GenderId ?? Guid.Empty,
                GenreId = actor.GenreId ?? Guid.Empty,
                Lastname = actor.Lastname,
                Fullname = actor.Fullname,
                GenderSelectList = (await _genderRepository.GetAllGenders()).
                    Select(gender => new SelectListItem
                    {
                        Text = gender.Description,
                        Value = gender.GenderId.ToString()
                    }),
                GenreSelectList = (await _genreRepository.GetAllGenres())
                    .Select(genre => new SelectListItem
                    {
                        Text = genre.Title,
                        Value = genre.GenreId.ToString()
                    })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("actors/{id:guid}")]
        public async Task<ActionResult> Details(ActorDetailsViewModel formData)
        {
            if (ModelState.IsValid)
            {
                await _actorService.UpdateActorAsync(new Actor
                {
                    ActorId = formData.ActorId,
                    DateOfBirth = formData.DateOfBirth,
                    Firstname = formData.Firstname,
                    GenderId = formData.GenderId,
                    GenreId = formData.GenreId,
                    Lastname = formData.Lastname,
                });

                return RedirectToAction("index");
            }

            formData.GenderSelectList = (await _genderRepository.GetAllGenders()).
                    Select(gender => new SelectListItem
                    {
                        Text = gender.Description,
                        Value = gender.GenderId.ToString()
                    });
            formData.GenreSelectList = (await _genreRepository.GetAllGenres())
                .Select(genre => new SelectListItem
                {
                    Text = genre.Title,
                    Value = genre.GenreId.ToString()
                });

            return View(formData);
        }

        // GET: Actors/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Actor actor = await db.Actors.FindAsync(id);
        //    if (actor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(actor);
        //}

        //// GET: Actors/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Actors/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Name,DateOfBirth,Gender,Genre")] Actor actor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Actors.Add(actor);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(actor);
        //}

        //// GET: Actors/Edit/5
        //public async Task<ActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Actor actor = await db.Actors.FindAsync(id);
        //    if (actor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(actor);
        //}

        //// POST: Actors/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DateOfBirth,Gender,Genre,IsActive,DateAdded,AddedBy")] Actor actor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(actor).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(actor);
        //}

        //// GET: Actors/Delete/5
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Actor actor = await db.Actors.FindAsync(id);
        //    if (actor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(actor);
        //}

        //// POST: Actors/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    Actor actor = await db.Actors.FindAsync(id);
        //    db.Actors.Remove(actor);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
