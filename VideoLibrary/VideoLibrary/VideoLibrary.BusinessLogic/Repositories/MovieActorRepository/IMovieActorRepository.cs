using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.MovieActorRepository
{
    public interface IMovieActorRepository
    {
        Task AddMovieActor(MovieActor movieActor);

        Task<List<MovieActor>> ActorsForMovies(int movieId);
    }
}
