using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.MovieRepository
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetAllMovies();
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(Guid genreId);
        Task<IEnumerable<Movie>> GetMoviesByActorAsync(Guid actorId);
        Task<IEnumerable<Movie>> GetMoviesByDateAddedAsync(DateTime dateAdded);
        Task<IEnumerable<Movie>> GetMoviesByYearAddedAsync(int yearAdded);
        Task<Movie> GetMovieByIdAsync(Guid movieId);
        Task<Movie> AddMovieAsync(Movie movie);
        Task AddMovieActorAsync(Guid movieId, Guid actorId, string role, bool leadActor);
        Task UpdateMovieAsync(Movie movie);
        Task RemoveMovieAsync(Guid movieId);
    }
}
