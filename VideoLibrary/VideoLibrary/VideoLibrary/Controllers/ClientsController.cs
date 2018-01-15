using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Services.ClientCrudService;
using System.Linq;
using VideoLibrary.Models.ViewModels;
using System;
using VideoLibrary.BusinessLogic.Repositories.GenderRepository;

namespace VideoLibrary.Controllers
{
    public class ClientsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        private readonly IClientCrudService _clientCrudService;
        private readonly IGenderRepository _genderRepository;

        public ClientsController(IClientCrudService clientCrudService, IGenderRepository genderRepository)
        {
            _clientCrudService = clientCrudService;
            _genderRepository = genderRepository;
        }

        // GET: Clients
        public async Task<ActionResult> Index(string search)
        {
            var model = (await _clientCrudService.GetAllClientsAsync())
                .Select(client => new ClientListViewModel
                {
                    ClientId = client.ClientId,
                    DateOfBirth = client.DateOfBirth == null ? string.Empty : DateTime.Parse(client.DateOfBirth.ToString()).ToString("dd/MM/yyyy"),
                    Fullname = client.Fullname,
                    Gender = client.Gender.Description
                });

            if (!string.IsNullOrWhiteSpace(search))
            {
                model = model.Where(client => client.Fullname.ToLower().Contains(search.ToLower()));
                ViewData["Search"] = search;
            }

            return View(model);
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public async Task<ActionResult> Create()
        {
            var model = new AddClientViewModel
            {
                GenderSelectList = (await _genderRepository.GetAllGenders())
                    .Select(gender => new SelectListItem
                    {
                        Text = gender.Description,
                        Value = gender.GenderId.ToString()
                    })
            };

            return View(model);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Firstname,Lastname,DateOfBirth,GenderId")] AddClientViewModel formData)
        {
            if (ModelState.IsValid)
            {
                await _clientCrudService.AddClientAsync(new Client
                {
                    ClientId = Guid.NewGuid(),
                    DateOfBirth = formData.DateOfBirth,
                    FirstName = formData.Firstname,
                    GenderId = formData.GenderId,
                    LastName = formData.Lastname
                });

                return RedirectToAction("index");
            }

            formData.GenderSelectList = (await _genderRepository.GetAllGenders())
                    .Select(gender => new SelectListItem
                    {
                        Text = gender.Description,
                        Value = gender.GenderId.ToString()
                    });

            return View(formData);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,DateOfBirth,Gender,IsActive,DateAdded,AddedBy")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Client client = await db.Clients.FindAsync(id);
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
