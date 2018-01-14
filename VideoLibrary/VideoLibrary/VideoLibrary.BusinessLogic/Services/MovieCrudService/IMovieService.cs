using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Services.MovieCrudService
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies();
        Task<Movie> GetMovieDetails(long? id);
        Task<Movie> DeleteMovie(long? id);
        Task<Movie> GetMovie(long? id);
        Task<Movie> InsertMovie(Movie model);
        Task<Movie> UpdateMovie(Movie model);
        /// <summary>
        /// Get all movies that match the title
        /// </summary>
        /// <param name="title">The movie title to search for</param>
        /// <returns></returns>
        Task<List<Movie>> GetMovieByTitle(string title);
        /// <summary>
        /// Get the most recently added movies
        /// </summary>
        /// <param name="number">Number of movies to return</param>
        /// <returns>a List of Movies</returns>
        List<Movie> GetRecentMovies(int number);

        /// <summary>
        /// Gets the number of movies per Genre
        /// </summary>
        /// <returns></returns>
        List<MoviesPerGenre> GetCountPerGenre();
    }
}
