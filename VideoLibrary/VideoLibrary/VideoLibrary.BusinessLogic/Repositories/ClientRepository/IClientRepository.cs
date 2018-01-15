using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.ClientRepository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetClientByIdAsync(Guid clientId);
        Task<Client> AddClientAsync(Client client);
        Task RemoveClientAsync(Guid clientId);
        Task UpdateClientAsync(Client client);
        Task<IEnumerable<Client>> GetClientsBorrowedMovie();
        Task<IEnumerable<Client>> GetClientsBorrowedMovieAsync(Guid movieId);
        Task<IEnumerable<Client>> GetClientsBornOnDay(int month, int day);       
    }
}