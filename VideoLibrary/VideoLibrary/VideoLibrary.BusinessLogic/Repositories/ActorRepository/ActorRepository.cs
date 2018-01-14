using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.ActorRepository
{
    public class ActorRepository : IActorRepository
    {
        private readonly LibraryContext _db;

        public ActorRepository(LibraryContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Add a new actor to the repository.
        /// </summary>
        /// <param name="actor">Actor to be added.</param>
        /// <returns>Actor added</returns>
        public async Task<Actor> AddActorAsync(Actor actor)
        {
            var newActor = _db.Actors.Add(actor);
            await _db.SaveChangesAsync();

            return newActor;
        }

        /// <summary>
        /// Get actor given the actor Id.
        /// </summary>
        /// <param name="actorId">Actor Id</param>
        /// <returns>Actor</returns>
        public async Task<Actor> GetActorByIdAsync(Guid actorId)
        {
            var actors = await GetAllActorsAsync();
            return actors.ToList().SingleOrDefault(a => a.ActorId == actorId);
        }

        /// <summary>
        /// Get all actors.
        /// </summary>
        /// <returns>List of actors.</returns>
        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            return await _db.Actors.Include(actor => actor.Gender).Include(actor => actor.Genre).ToListAsync();
        }

        /// <summary>
        /// Get all actors by gender.
        /// </summary>
        /// <param name="genderId">Id of gender.</param>
        /// <returns>List of actors.</returns>
        public async Task<IEnumerable<Actor>> GetAllActorsByGenderAsync(Guid genderId)
        {
            var actors = await GetAllActorsAsync();
            return actors.Where(actor => actor.GenderId == genderId).ToList();
        }

        /// <summary>
        /// Remove actor given the actor Id.
        /// </summary>
        /// <param name="actorId">Actor Id.</param>
        /// <returns>Task result.</returns>
        public async Task RemoveActorAsync(Guid actorId)
        {
            var actorToRemove = (await GetAllActorsAsync()).SingleOrDefault(actor => actor.ActorId == actorId);

            if (actorToRemove == null)
            {
                throw new KeyNotFoundException($"Actor with Id {actorId} was not found.");
            }

            _db.Actors.Remove(actorToRemove);
            await _db.SaveChangesAsync();
        }
        /// <summary>
        /// Update actor given the update details.
        /// </summary>
        /// <param name="actor">Actor updates.</param>
        /// <returns>Task results.</returns>
        public async Task UpdateActorAsync(Actor actor)
        {
            var actorToUpdate = (await GetAllActorsAsync()).SingleOrDefault(a => a.ActorId == actor.ActorId);

            if (actorToUpdate == null)
            {
                throw new KeyNotFoundException($"Actor with Id {actor.ActorId} was not found.");
            }

            actorToUpdate.DateOfBirth = actor.DateOfBirth;
            actorToUpdate.Firstname = actor.Firstname;
            actorToUpdate.Lastname = actor.Lastname;
            actorToUpdate.GenderId = actor.GenderId;
            actorToUpdate.GenreId = actor.GenreId;

            _db.Entry(actorToUpdate).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
