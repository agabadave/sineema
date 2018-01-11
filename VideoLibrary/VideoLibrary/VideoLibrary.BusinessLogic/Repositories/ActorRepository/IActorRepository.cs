using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.ActorRepository
{
    public interface IActorRepository
    {
        IQueryable<Actor> GetAllActors();
        Task<Actor> GetActorByIdAsync(Guid actorId);
        Task<IEnumerable<Actor>> GetAllActorsByGenderAsync(Guid genderId);
        Task<Actor> AddActorAsync(Actor actor);
        Task UpdateActorAsync(Actor actor);
        Task RemoveActorAsync(Guid actorId);
    }
}
