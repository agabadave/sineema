using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly LibraryContext _db;

        public ClientRepository(LibraryContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Add client.
        /// </summary>
        /// <param name="client">Client to add.</param>
        /// <returns>Client added.</returns>
        public async Task<Client> AddClientAsync(Client client)
        {
            var newClient = _db.Clients.Add(client);
            await _db.SaveChangesAsync();

            return newClient;
        }

        /// <summary>
        /// List all the clients.
        /// </summary>
        /// <returns>List of clients.</returns>
        public IQueryable<Client> GetAllClients()
        {
            return _db.Clients;
        }

        /// <summary>
        /// Get client given the client Id.
        /// </summary>
        /// <param name="clientId">Id of client.</param>
        /// <returns>Client</returns>
        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            return await GetAllClients().SingleOrDefaultAsync(client => client.ClientId == clientId);
        }

        /// <summary>
        /// Get all the clients that are born on a given day in a month.
        /// </summary>
        /// <param name="month">Calendar month.</param>
        /// <param name="day">Day</param>
        /// <returns>List of clients.</returns>
        public async Task<IEnumerable<Client>> GetClientsBornOnDay(int month, int day)
        {
            return await GetAllClients()
                .Where(client => client.DateOfBirth.Value.Month == month && client.DateOfBirth.Value.Day == day).ToListAsync();
        }

        /// <summary>
        /// Get all clients that have borrowed a movie.
        /// </summary>
        /// <returns>List of clients.</returns>
        public IQueryable<Client> GetClientsBorrowedMovie()
        {
            return _db.BorrowedMovies.Include(b => b.Client).Select(b => b.Client);
        }

        /// <summary>
        /// Get all the client that have borrowed a movie specified by Id.
        /// </summary>
        /// <param name="movieId">Movie Id.</param>
        /// <returns>List of clients.</returns>
        public async Task<IEnumerable<Client>> GetClientsBorrowedMovieAsync(Guid movieId)
        {
            return await _db.BorrowedMovies
                    .Include(b => b.Client)
                    .Where(b => b.MovieId == movieId)
                    .Select(b => b.Client)
                    .ToListAsync();
        }

        /// <summary>
        /// Remove a client from the repository.
        /// </summary>
        /// <param name="clientId">Id of the client.</param>
        /// <returns>Task result.</returns>
        public async Task RemoveClientAsync(Guid clientId)
        {
            var clientToRemove = await GetAllClients().SingleOrDefaultAsync(client => client.ClientId == clientId);

            if (clientToRemove == null)
            {
                throw new KeyNotFoundException($"Client with Id {clientId} was not found.");
            }

            _db.Clients.Remove(clientToRemove);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Update client.
        /// </summary>
        /// <param name="client">Client update details.</param>
        /// <returns>Task result.</returns>
        public async Task UpdateClientAsync(Client client)
        {
            var clientToUpdate = await GetAllClients().SingleOrDefaultAsync(c => c.ClientId == client.ClientId);

            if (clientToUpdate == null)
            {
                throw new KeyNotFoundException($"Client with Id {client.ClientId} was not found.");
            }

            clientToUpdate.DateOfBirth = client.DateOfBirth;
            clientToUpdate.FirstName = client.FirstName;
            clientToUpdate.LastName = client.LastName;
            clientToUpdate.GenderId = client.GenderId;

            _db.Entry(clientToUpdate).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
