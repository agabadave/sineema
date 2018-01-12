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
        /// Get movie by Id.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>Movie</returns>
        public async Task<Movie> GetMovieByIdAsync(Guid movieId)
        {
            return await GetAllMovies().SingleOrDefaultAsync(movie => movie.MovieId == movieId);
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

        /// <summary>
        /// Remove movie.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>Task result.</returns>
        public async Task RemoveMovieAsync(Guid movieId)
        {
            var movieToRemove = await GetMovieByIdAsync(movieId);

            if (movieToRemove == null)
            {
                throw new KeyNotFoundException($"Movie with Id {movieId} was not found");
            }

            using (_db)
            {
                _db.Movies.Remove(movieToRemove);
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Update movie details.
        /// </summary>
        /// <param name="movie">Movie update details.</param>
        /// <returns>Task result.</returns>
        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            var movieToUpdate = await GetMovieByIdAsync(movie.MovieId);

            if (movieToUpdate == null)
            {
                throw new KeyNotFoundException($"Movie with Id {movie.MovieId} was not found.");
            }

            movieToUpdate.Duration = movie.Duration;
            movieToUpdate.GenreId = movie.GenreId;
            movieToUpdate.Title = movie.Title;

            using (_db)
            {
                _db.Entry(movieToUpdate).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }

            return movieToUpdate;
        }
    }
}
