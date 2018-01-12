using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.ActorRepository;

namespace VideoLibrary.BusinessLogic.Services.ActorCrudService
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            return await _actorRepository.GetAllActors().ToListAsync();
        }

        public async Task<IEnumerable<Actor>> GetActorByIdAsync(Guid gender)
        {
            return await _actorRepository.GetAllActorsByGenderAsync(gender);
        }


        public async Task SaveActorAsync(Actor model)
        {
            await _actorRepository.AddActorAsync(model);
        }
    }
}
