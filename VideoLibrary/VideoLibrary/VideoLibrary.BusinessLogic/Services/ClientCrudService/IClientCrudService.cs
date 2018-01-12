using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Services.ClientCrudService
{
    public interface IClientCrudService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();

        Task<Client> GetClientByIdAsync(Guid clientId);
    }
}