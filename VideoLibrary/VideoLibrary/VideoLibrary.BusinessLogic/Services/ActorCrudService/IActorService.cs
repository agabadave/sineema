using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Services.ActorCrudService
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetActorsAsync();

        Task<Actor> GetActorByIdAsync(Guid gender);

        Task SaveActorAsync(Actor model);
    }
}
