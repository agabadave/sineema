using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;

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

        public List<Movie> GetRecent()
        {
            return _movieRepository.GetMostRecent();
        }

        public List<string[]> GetDistributionByGenre()
        {
            return _movieRepository.GetDistributionByGenre();
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

        public async Task<List<Movie>> SearchMovies(string query, string sortOrder, int itemsPerPage, int pageToDisplay)
        {
            return await _movieRepository.SearchMovies(query, sortOrder, itemsPerPage, pageToDisplay);
        }
    }
}