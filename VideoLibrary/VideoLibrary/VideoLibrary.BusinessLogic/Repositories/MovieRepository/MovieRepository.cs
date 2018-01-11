using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.MovieRepository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly LibraryContext _db;

        public MovieRepository(LibraryContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Add movie actor.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <param name="actorId">Id of the actor.</param>
        /// <param name="role">Role of the actor in the movie.</param>
        /// <param name="leadActor">Actor is the lead.</param>
        /// <returns>Task result.</returns>
        public async Task AddMovieActorAsync(Guid movieId, Guid actorId, string role, bool leadActor = false)
        {
            using (_db)
            {
                _db.MovieActors.Add(new MovieActor
                {
                    ActorId = actorId,
                    LeadActor = leadActor,
                    MovieId = movieId,
                    Role = role
                });
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Add new movie.
        /// </summary>
        /// <param name="movie">Movie to add.</param>
        /// <returns>Movie added.</returns>
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            using (_db)
            {
                var newMovie = _db.Movies.Add(movie);
                await _db.SaveChangesAsync();

                return newMovie;
            }
        }

        /// <summary>
        /// Get all the movies.
        /// </summary>
        /// <returns>List of movies.</returns>
        public IQueryable<Movie> GetAllMovies()
        {
            using (_db)
            {
                return _db.Movies;
            }
        }

        /// <summary>
        /// Get all movies by actor.
        /// </summary>
        /// <param name="actorId">Actor Id.</param>
        /// <returns>List of movies.</returns>
        public async Task<IEnumerable<Movie>> GetMoviesByActorAsync(Guid actorId)
        {
            using (_db)
            {
                return await _db.MovieActors.Include(ma => ma.Movie).Where(ma => ma.ActorId == actorId)
                    .Select(ma => ma.Movie).ToListAsync();
            }
        }

        /// <summary>
        /// Get movies by the date added.
        /// </summary>
        /// <param name="dateAdded">Date when the movie was added.</param>
        /// <returns>List of movies.</returns>
        public async Task<IEnumerable<Movie>> GetMoviesByDateAddedAsync(DateTime dateAdded)
        {
            return await GetAllMovies().Where(m => m.DateAdded == dateAdded).ToListAsync();
        }
        /// <summary>
        /// Get movies by genre.
        /// </summary>
        /// <param name="genreId">Id of genre.</param>
        /// <returns>List of movies.</returns>
        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(Guid genreId)
        {
            return await GetAllMovies().Where(m => m.GenreId == genreId).ToListAsync();
        }

        /// <summary>
        /// Get movies by the year they were added.
        /// </summary>
        /// <param name="yearAdded">Year</param>
        /// <returns>List of movies.</returns>
        public async Task<IEnumerable<Movie>> GetMoviesByYearAddedAsync(int yearAdded)
        {
            return await GetAllMovies().Where(m => m.DateAdded.Year == yearAdded).ToListAsync();
        }

        public Task RemoveMovieAsync(Guid movieId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
