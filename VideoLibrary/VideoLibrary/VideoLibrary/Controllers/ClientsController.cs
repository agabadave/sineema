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

        // GET: Clients/Create
        public async Task<ActionResult> Create()
        {
            var model = new AddClientViewModel
            {
                GenderSelectList = await GetGendersListAsync()
            };

            return View(model);
        }

        private async Task<System.Collections.Generic.IEnumerable<SelectListItem>> GetGendersListAsync()
        {
            return (await _genderRepository.GetAllGenders())
                                .Select(gender => new SelectListItem
                                {
                                    Text = gender.Description,
                                    Value = gender.GenderId.ToString()
                                });
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

            formData.GenderSelectList = await GetGendersListAsync();

            return View(formData);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            Client client = await _clientCrudService.GetClientByIdAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            var model = new ClientDetailsViewModel
            {
                ClientId = client.ClientId,
                DateOfBirth = client.DateOfBirth,
                Firstname = client.FirstName,
                GenderId = client.GenderId,
                Lastname = client.LastName,
                Fullname = client.Fullname,
                GenderSelectList = await GetGendersListAsync()
            };

            return View(model);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClientId,Firstname,Lastname,DateOfBirth,GenderId")] ClientDetailsViewModel formData)
        {
            if (ModelState.IsValid)
            {
                await _clientCrudService.UpdateClientAsync(new Client
                {
                    ClientId = formData.ClientId,
                    DateOfBirth = formData.DateOfBirth,
                    FirstName = formData.Firstname,
                    GenderId = formData.GenderId,
                    LastName = formData.Lastname
                });

                return RedirectToAction("index");
            }

            formData.GenderSelectList = await GetGendersListAsync();

            return View(formData);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            Client client = await _clientCrudService.GetClientByIdAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            var model = new ClientDeleteViewModel
            {
                ClientId = client.ClientId,
                DateOfBirth = client.DateOfBirth == null ? string.Empty : DateTime.Parse(client.DateOfBirth.ToString()).ToString("dd/MM/yyyy"),
                Firstname = client.FirstName,
                Gender = client.Gender == null ? string.Empty : client.Gender.Description,
                Fullname = client.Fullname,
                Lastname = client.LastName
            };

            return View(model);
        }

        // POST: Clients/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ClientDeleteViewModel formData)
        {
            if (ModelState.IsValid)
            {
                await _clientCrudService.RemoveClientAsync(formData.ClientId);
                return RedirectToAction("Index");
            }
            
            return View(formData);
        }
    }
}
