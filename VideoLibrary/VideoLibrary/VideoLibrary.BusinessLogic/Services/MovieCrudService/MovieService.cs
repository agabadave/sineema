using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;
using System.Linq;
using VideoLibrary.BusinessEntities.Models;

namespace VideoLibrary.BusinessLogic.Services.MovieCrudService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Task<List<Movie>> GetMovies()
        {
            return _movieRepository.GetAll();
        }

        public async Task<Movie> GetMovieDetails(long? id)
        {
            return await _movieRepository.Get(id);
        }

        public async Task<Movie> DeleteMovie(long? id)
        {
            var movie = await _movieRepository.Get(id);

            return await _movieRepository.DeleteAsync(movie);
        }

        public async Task<Movie> GetMovie(long? id)
        {
            return await _movieRepository.Get(id);
        }

        public async Task<Movie> InsertMovie(Movie model)
        {
            return await _movieRepository.InsertAsync(model);
        }

        public async Task<Movie> UpdateMovie(Movie model)
        {
            return await _movieRepository.UpdateAsync(model);
        }

        public async Task<List<Movie>> GetMovieByTitle(string title)
        {
            return await _movieRepository.GetMoviesWhere((m) => m.Title.Contains(title));
        }
        #region todo
        //Count by Genre
        public List<MoviesPerGenre> GetCountPerGenre()
        {
            var movies = Task.Run(()=>_movieRepository.GetAll()).Result;
            var moviesPerGenre = from m in movies
            group m by m.Genre into t
            select new MoviesPerGenre { Count = t.Count(), Title = t.Key.ToString() };

            var result = moviesPerGenre.ToList();
            return result;
        }
        //Most Recent 5 movies
        public List<Movie> GetRecentMovies(int number)
        {
           return _movieRepository.GetMovies().OrderByDescending(m => m.DateAdded).Take(number).ToList();
        }
        //Top five actors by movie count
        #endregion
    }

    public class MoviesPerGenre
    {
        public string Title { get; set; }
        public int Count { get; set; }
    }
}