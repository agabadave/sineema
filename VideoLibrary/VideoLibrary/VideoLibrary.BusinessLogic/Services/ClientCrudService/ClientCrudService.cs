using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.ClientRepository;

namespace VideoLibrary.BusinessLogic.Services.ClientCrudService
{
    public class ClientCrudService : IClientCrudService
    {
        private readonly IClientRepository _clientRepository;

        public ClientCrudService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task AddClientAsync(Client client)
        {
            await _clientRepository.AddClientAsync(client);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return (await _clientRepository.GetAllClients()).ToList();
        }

        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            return await _clientRepository.GetClientByIdAsync(clientId);
        }

        public async Task RemoveClientAsync(Guid clientId)
        {
            await _clientRepository.RemoveClientAsync(clientId);
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _clientRepository.UpdateClientAsync(client);
        }
    }
}