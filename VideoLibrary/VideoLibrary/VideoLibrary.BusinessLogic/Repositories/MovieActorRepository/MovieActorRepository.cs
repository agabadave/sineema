using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.MovieActorRepository
{
    public class MovieActorRepository : IMovieActorRepository
    {
        private LibraryContext _db;

        public MovieActorRepository(LibraryContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<MovieActor>> GetMovieActorsAsync(Guid movieId)
        {
            return await _db.MovieActors
                .Include(movieActor => movieActor.Actor)
                .Include(movieActor => movieActor.Movie)
                .Where(x => x.MovieId == movieId).ToListAsync();
        }

        public async Task UpdateMovieActorAsync(MovieActor movieActor)
        {
            var movieActorToUpdate = await _db.MovieActors.FindAsync(movieActor.MovieActorId);

            if (movieActorToUpdate == null)
            {
                throw new KeyNotFoundException($"Movie actor with record Id {movieActor.MovieActorId} was not found.");
            }

            movieActorToUpdate.Role = movieActor.Role;
            movieActorToUpdate.LeadActor = movieActor.LeadActor;

            _db.Entry(movieActorToUpdate).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
